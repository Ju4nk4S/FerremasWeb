import { Component } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css'
})
export class InicioComponent {
  constructor(private router: Router) { }

  public Ferreteria = "FerremasWeb"
  public Navegar() {
    this.router.navigate(['/login']);
  }

}