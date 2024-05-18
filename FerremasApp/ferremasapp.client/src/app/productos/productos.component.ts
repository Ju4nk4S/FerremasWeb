import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../servicios-api/producto';


@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css'
})
export class ProductoComponent implements OnInit {

  public listaProductos!: any[];
  constructor(private servicioProducto: ProductoService) {


  }

  ngOnInit(): void {
    this.dameProductos()

  }

  dameProductos() {
    this.servicioProducto.dameProductos().subscribe(res => {
      this.listaProductos = res.objetoGenerico;
    });

  }


}

