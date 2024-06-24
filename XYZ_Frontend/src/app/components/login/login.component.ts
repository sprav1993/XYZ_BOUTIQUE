import { Component, OnInit } from '@angular/core';
import { User } from '../../Interface/User';
import { LoginService } from '../../services/login.service';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
// Import Angular Material modules
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

// export class LoginComponent implements OnInit {
//   user: User;

//   constructor(private loginService: LoginService) {
//     // Inicialización del objeto `user`
//     this.user = {
//       UserId: 0,
//       FirstName: '',
//       LastName: '',
//       UserName: '',
//       Password: '',
//       Token: ''
//     };
//   }

//   ngOnInit(): void {
//     // Aquí puedes cargar datos o inicializar componentes adicionales
//   }

//   saveUser(): void {
//     this.loginService.login(this.user).subscribe(
//       response => {
//         // Manejar la respuesta exitosa aquí
//         console.log('User logged in:', response);
//       },
//       error => {
//         // Manejar el error aquí
//         console.error('Error logging in:', error);
//       }
//     );
//   }
// }
export class LoginComponent implements OnInit {
  form: FormGroup;
  error: any;

  user: User = {  // Inicializa el objeto `user`
    UserId: 0,
    FirstName: '',
    LastName: '',
    UserName: '',
    Password: '',
    Token: ''
  };

  constructor(private fb: FormBuilder, private loginService: LoginService,     private router: Router,
  ) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Aquí puedes cargar datos o inicializar componentes adicionales
  }

  submit(): void {
    if (this.form.valid) {
      this.user.UserName = this.form.get('username')?.value;
      this.user.Password = this.form.get('password')?.value;

      this.loginService.login(this.user).subscribe(
        (response:any) => {
           if (response.IsSuccess) {
            this.user.Token = response.Data.Token; // Asignar el token al objeto user
            // Aquí puedes guardar el token en localStorage, sessionStorage, etc.
            // Redirigir a otra página, mostrar mensaje de éxito, etc.
            localStorage.setItem('token', response.Data.Token);

            this.router.navigateByUrl('/menu');
            // Swal.fire({
            //   icon: 'success',
            //   title: 'Login Successful',
            //   text: response.Message,
            // });
          } else {
            this.error = 'Error logging in';
            console.error('Error logging in:', response.Message);
            Swal.fire({
              icon: 'error',
              title: 'Login Error',
              text: response.Message,
            });
          }

        },
        error => {
          this.error = 'Error logging in';
          console.error('Error logging in:', error);
          Swal.fire({
            icon: 'error',
            title: 'Login Error',
            text: 'Invalid username or password. Please try again.',
          });
        }
      );
    } else {
      this.form.markAllAsTouched();
    }
  }
}
