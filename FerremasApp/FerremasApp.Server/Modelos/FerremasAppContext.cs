using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FerremasApp.Server.Modelos
{
    public partial class FerremasAppContext : DbContext
    {
        public FerremasAppContext()
        {
        }

        public FerremasAppContext(DbContextOptions<FerremasAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; } = null!;
        public virtual DbSet<Bodegero> Bodegeros { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Clientes2> Clientes2s { get; set; } = null!;
        public virtual DbSet<Contador> Contadors { get; set; } = null!;
        public virtual DbSet<LineaPedido> LineaPedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ReporteUsuario> ReporteUsuarios { get; set; } = null!;
        public virtual DbSet<UsuariosApi> UsuariosApis { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=A01\\SQL;Initial Catalog=FerremasApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("ADMINISTRADOR");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Rut)
                    .HasMaxLength(20)
                    .HasColumnName("RUT");

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            modelBuilder.Entity<Bodegero>(entity =>
            {
                entity.ToTable("BODEGERO");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");

                entity.HasIndex(e => e.Email, "IX_CLIENTES")
                    .IsUnique();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clientes2>(entity =>
            {
                entity.ToTable("CLIENTES2");

                entity.HasIndex(e => e.Email, "IX_CLIENTES2")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Contador>(entity =>
            {
                entity.ToTable("CONTADOR");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            modelBuilder.Entity<LineaPedido>(entity =>
            {
                entity.ToTable("LINEA_PEDIDO");

                entity.Property(e => e.ImporteUnitario).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.LineaPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LINEA_PEDIDO_PEDIDOS");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.LineaPedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LINEA_PEDIDO_PRODUCTO");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("PEDIDOS");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Pedido)
                    .HasForeignKey<Pedido>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDOS_CLIENTES2");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PEDIDOS_CLIENTES");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ReporteUsuario>(entity =>
            {
                entity.ToTable("REPORTE_USUARIO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<UsuariosApi>(entity =>
            {
                entity.ToTable("USUARIOS_API");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("VENDEDOR");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
