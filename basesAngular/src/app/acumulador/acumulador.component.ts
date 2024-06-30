import { Component } from '@angular/core';

@Component({
  selector: 'app-acumulador',
  standalone: true,
  imports: [],
  templateUrl: './acumulador.component.html',
  styleUrl: './acumulador.component.css'
})
export class AcumuladorComponent {
  title = "Bases de Angular";
  numero : number = 2;

  duplicar() {
    this.numero *= 2;
  }
  triplicar() {
    this.numero *= 3;
  }
  reiniciar() {
    this.numero = 2;
  }
}
