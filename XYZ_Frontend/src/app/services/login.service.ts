import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Interface/User';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }
  login(user: User){
    console.log('login',user );
    console.log('entro al servicio' );

    return this.http.post('http://localhost:5035/api/Users',user);
  }

  getToken(){
    // const token = localStorage.getItem('token');
    // console.log('token',token);
    return localStorage.getItem('token');
    ;
  }
}

