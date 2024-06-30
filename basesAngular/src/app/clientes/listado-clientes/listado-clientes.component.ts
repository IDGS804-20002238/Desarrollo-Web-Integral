import { Component, Input, input } from '@angular/core';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-listado-clientes',
  templateUrl: './listado-clientes.component.html',
  styleUrl: './listado-clientes.component.css'
})
export class ListadoClientesComponent {
  clientes: ICliente[] = [];
  constructor() {
    // Obtener los clientes existentes del local storage
    const storedClientes = localStorage.getItem('clientes');
    if (storedClientes) {
      this.clientes = JSON.parse(storedClientes);
    }
  }
  eliminarCliente(noEmpleado: number) {
    // Eliminar el cliente del local storage
    const storedClientes = localStorage.getItem('clientes');
    if (storedClientes) {
      const clientes: ICliente[] = JSON.parse(storedClientes);
      const index = clientes.findIndex(cliente => cliente.noEmpleado === (noEmpleado));
      if (index !== -1) {
        clientes.splice(index, 1);
        localStorage.setItem('clientes', JSON.stringify(clientes));
        this.clientes = clientes;
      }
    }
  }

}
