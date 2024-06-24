// import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';

// @Injectable({
//   providedIn: 'root'
// })
// export class UsuarioService {

//   private apiUrl = 'http://localhost:5035/api/Customer/async';

//   constructor(private http: HttpClient) { }

//   getUsuarios(): Observable<any> {
//     // Obtener el token de localStorage
//     const token = localStorage.getItem('token');

//     // Verificar si el token está presente
//     if (!token) {
//       throw new Error('No se encontró el token en el localStorage.');
//     }

//     // Configurar el encabezado con el token Bearer
//     const headers = new HttpHeaders({
//       'Authorization': `Bearer ${token}`
//     });
// debugger
//     // Realizar la solicitud GET con el encabezado configurado
//     return this.http.get(this.apiUrl, { headers });
//   }

// }
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<any> {
    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No se encontró el token en el localStorage.');
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    return this.http.get('http://localhost:5035/api/Customer/async')
    ;
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // Error del lado del cliente
      console.error('Error del lado del cliente:', error.error.message);
    } else {
      // El servidor devolvió un código de error
      console.error(`Código de error ${error.status}, ` + `mensaje: ${error.error}`);
    }
    // Devuelve un observable con un mensaje de error orientado al usuario
    return throwError('Hubo un problema al realizar la solicitud. Por favor, intenta nuevamente más tarde.');
  }
}
