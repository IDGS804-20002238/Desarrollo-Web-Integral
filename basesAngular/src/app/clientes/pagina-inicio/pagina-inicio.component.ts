import { Component } from '@angular/core';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-pagina-inicio',
  templateUrl: './pagina-inicio.component.html',
  styleUrl: './pagina-inicio.component.css'
})
export class PaginaInicioComponent {

  clientes: ICliente[] = [];
  agregarNuevoCliente(cliente : ICliente){
    //Agregamos el nuevo cliente a la lista
    this.clientes.push(cliente);
  }
}
