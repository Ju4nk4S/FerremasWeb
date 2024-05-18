import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ClienteService } from '../servicios-api/cliente';
import { Cliente } from '../modelos/cliente';

@Component({
  selector: 'app-cliente-component',
  templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {
  altaForm!: FormGroup;
  enviado = false;
  resultadoPeticion: string = '';
  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;

  constructor(
    private servicioCliente: ClienteService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.altaForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      pass: ['', [Validators.required]]
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.altaForm.controls;
  }

  public onSubmit(): void {
    this.enviado = true;
    if (this.altaForm.invalid) {
      console.log("Invalido");
      return;
    }

    console.log("valido");

    let cliente: Cliente = {
      nombre: this.altaForm.controls['nombre'].value,
      email: this.altaForm.controls['email'].value,
      pass: this.altaForm.controls['pass'].value
    };

    this.servicioCliente.agregarCliente(cliente).subscribe(res => {
      if (res.error != null && res.error !== '')
        this.resultadoPeticion = res.texto;
      else
        this.resultadoPeticion = "Cliente dado de alta correctamente. Inicie sesión";

      this.modalService.open(this.myModalInfo);
    });
  }
}
