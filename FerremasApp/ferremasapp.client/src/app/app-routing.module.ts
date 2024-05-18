import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { MisDatosComponent } from './mis-datos/mis-datos.component';
import { ProductoComponent } from './productos/productos.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LoginComponent } from './login/login.component';
import { HistoricoPedidosComponent } from './historico-pedidos/historico-pedidos.component';

const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'inicio', component: InicioComponent },
  { path: 'mis-datos', component: MisDatosComponent },
  { path: 'productos', component: ProductoComponent },
  { path: 'cliente', component: ClienteComponent },
  { path: 'login', component: LoginComponent },
  { path: 'historico-pedidos', component: HistoricoPedidosComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
