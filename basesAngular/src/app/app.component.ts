import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AcumuladorComponent } from './acumulador/acumulador.component';
import { ClientesModule } from './clientes/clientes.module';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AcumuladorComponent, ClientesModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  
}
