import { HttpInterceptorFn } from '@angular/common/http';
import { LoginService } from '../services/login.service';
import { inject } from '@angular/core';
import { Routes } from '@angular/router';
import { catchError, throwError } from 'rxjs';

// export const authInterceptor: HttpInterceptorFn = (req, next) => {
//   // const loginService=inject(LoginService);
//   // const token = loginService.getToken();
//   // if (token) {
//   //   req = req.clone({
//   //     setHeaders: {
//   //       Authorization: `Bearer ${token}`
//   //     }
//   //   });
//   // }
//   // console.log('sasdsadasdsad',req)
//   // return next(req).pipe(
//   //   catchError((error) => {
//   //     const CODES = [401, 403];
//   //     if (CODES.includes(error.status)) {
//   //       console.log('Error:', error);
//   //     }
//   //     return throwError(()=>error);
//   //   })
//   // );
// };
