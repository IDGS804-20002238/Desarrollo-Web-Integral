import { Component, EventEmitter, Output } from '@angular/core';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-agregar-cliente',
  templateUrl: './agregar-cliente.component.html',
  styleUrl: './agregar-cliente.component.css'
})
export class AgregarClienteComponent {
  clientes: ICliente[] = [];
  nuevo: ICliente = { 
    noEmpleado: 0,
    nombre: '', 
    correo: '',
    telefono: 0,
    fechaNacimiento: new Date(),
    sexo: '',
  }; 
  @Output() onNuevoCliente: EventEmitter<ICliente> = new EventEmitter<ICliente>(); 
  
  
  agregar() {
    // Validaciones
    if (Object.values(this.nuevo).some(value => value === '' || value === null)) {
      console.log('Todos los campos son obligatorios');
      return;
    }
    // Guardar el nuevo cliente en el local storage
    const clientes = JSON.parse(localStorage.getItem('clientes') || '[]');
    clientes.push(this.nuevo);
    localStorage.setItem('clientes', JSON.stringify(clientes));

    // Emitir el nuevo evento para notificar el nuevo cliente
    this.onNuevoCliente.emit(this.nuevo);

    // Limpiar el formulario
    this.nuevo = {
        noEmpleado: 0,
        nombre: '', 
        correo: '',
        telefono: 0,
        fechaNacimiento: new Date(),
        sexo: '',
      };

    // Actualizar la página para reflejar los cambios en la tabla
    window.location.reload();
  }
}
