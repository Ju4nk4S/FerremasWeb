import { Component } from '@angular/core';
import { ClienteService } from '../servicios-api/cliente';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private servicioProducto: ClienteService) {
    servicioProducto.dameclientes().subscribe(res => { console.log(res) })
  }
}
