﻿using Microsoft.IdentityModel.Tokens;
using FerremasApp.Server.Modelos;
using FerremasApp.Server.Modelos.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FerremasApp.Server.Servicios
{
    public class UsuarioAPIServicio : IUsuarioAPI
    {
        private readonly IConfiguration configuration;
        public UsuarioAPIServicio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public UsuatioAPIViewmodels Autenticacion(AuthAPI authAPI)
        {
            UsuatioAPIViewmodels res = new UsuatioAPIViewmodels();
            byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Util util = new Util(keyBbyte);
            using (FerremasAppContext basedatos = new FerremasAppContext())
            {
                UsuariosApi usuarioAPI = basedatos.UsuariosApis.Single(usuario => usuario.Email == authAPI.email);
                if (usuarioAPI != null &
                    authAPI.password == util.desCifrar(Encoding.ASCII.GetString(usuarioAPI.Password), configuration["ClaveCifrado"]))
                {
                    res.email = usuarioAPI.Email;
                    res.token = GenerarTokenJWT(authAPI);
                }
                else
                {
                    throw new Exception("Usuario desconocido");
                }
            }

            return res;
        }


        //Generamos token
        private string GenerarTokenJWT(AuthAPI usuarioInfo)
        {
            // Cabecera
            var _symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"]));

            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var _Header = new JwtHeader(_signingCredentials);
            // Claims
            var _Claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.email),
            };
           
            //Payload
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(24));

            //Token
            var _Token = new JwtSecurityToken(_Header,_Payload);
            string token = new JwtSecurityTokenHandler().WriteToken(_Token);

            return token;
        }



    }
}
