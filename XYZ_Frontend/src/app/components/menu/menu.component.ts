import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    MatMenuModule, // Importa MatMenuModule
    MatIconModule,
    RouterLink,
    RouterOutlet // Opcional: Importa MatIconModule si deseas usar iconos en el menú

  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {

}
