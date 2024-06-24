// import { Component } from '@angular/core';
// import { MatTableDataSource } from '@angular/material/table';
// import { UsuarioService } from '../../services/usuario.service';
// // Importa los módulos de Angular Material que necesitas
// import { MatTableModule } from '@angular/material/table';
// import { MatInputModule } from '@angular/material/input';
// import { MatButtonModule } from '@angular/material/button';
// import { MatCardModule } from '@angular/material/card';

// @Component({
//   selector: 'app-usuario',
//   standalone: true,
//   imports: [ MatTableModule,
//     MatInputModule,
//     MatButtonModule,
//     MatCardModule],
//   templateUrl: './usuario.component.html',
//   styleUrl: './usuario.component.css'
// })
// export class UsuarioComponent {
//   displayedColumns: string[] = ['customerId', 'companyName', 'contactName', 'country', 'phone'];
//   dataSource: MatTableDataSource<any>;

//   constructor(private usuarioService: UsuarioService) {
//     this.dataSource = new MatTableDataSource<any>();
//   }

//   ngOnInit(): void {
//     this.loadUsuarios();
//   }

//   loadUsuarios(): void {
//     console.log(localStorage.getItem('token'));
//     this.usuarioService.getUsuarios().subscribe(
//       (Data:any) => {
//         this.dataSource.data = Data; // Asigna directamente los datos al dataSource
//       }
//     );
//   }
// }
import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-usuario',
    standalone: true,
    imports: [ MatTableModule,
      MatInputModule,
      MatButtonModule,
      MatCardModule,
      CommonModule,
    ],
    templateUrl: './usuario.component.html',
    styleUrl: './usuario.component.css'
  })
  export class UsuarioComponent implements OnInit {
    dataSource = new MatTableDataSource<any>(); // Fuente de datos para la tabla
    displayedColumns: string[] = [
      'CustomerId', 'CompanyName', 'ContactName', 'ContactTitle',
      'Address', 'City', 'Country', 'Phone', 'Fax'
    ]; // Columnas que se mostrarán en la tabla

    constructor(private usuarioService: UsuarioService) { }

    ngOnInit(): void {
      this.loadUsuarios();
    }

    loadUsuarios(): void {
      this.usuarioService.getUsuarios().subscribe(
        (data: any) => {
          console.log('Respuesta del servicio:', data);
          this.dataSource.data = data.Data; // Asigna los datos recibidos a la propiedad data del dataSource
        },
        (error) => {
          console.error('Error al obtener usuarios:', error); // Captura y muestra el error en consola
        }
      );
    }
  }
