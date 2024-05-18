import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { InicioComponent } from './inicio/inicio.component';
import { MisDatosComponent } from './mis-datos/mis-datos.component';
import { ProductosComponent } from './productos/productos.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LoginComponent } from './login/login.component';
import { HistoricoPedidosComponent } from './historico-pedidos/historico-pedidos.component';
import { ModelosComponent } from './modelos/modelos.component';
import { SeguridadComponent } from './seguridad/seguridad.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    InicioComponent,
    MisDatosComponent,
    ProductosComponent,
    ClienteComponent,
    LoginComponent,
    HistoricoPedidosComponent,
    ModelosComponent,
    SeguridadComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: InicioComponent, pathMatch: 'full' },
      { path: 'inicio', component: InicioComponent },
      { path: 'cliente', component: ClienteComponent },
      { path: 'login', component: LoginComponent }
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
