import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InicioComponent } from './inicio/inicio.component';
import { MisDatosComponent } from './mis-datos/mis-datos.component';
import { ProductoComponent } from './productos/productos.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LoginComponent } from './login/login.component';
import { HistoricoPedidosComponent } from './historico-pedidos/historico-pedidos.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InicioComponent,
    MisDatosComponent,
    ProductoComponent,
    ClienteComponent,
    LoginComponent,
    HistoricoPedidosComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
