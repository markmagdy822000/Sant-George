import { Register } from './../Components/register/register';
import { Injectable } from '@angular/core';
import { ILogin } from '../Models/ilogin';
import { Observable, Observer } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IRegister } from '../Models/iregister';


@Injectable({
  providedIn: 'root'
})
export class AuthServices {
  constructor(private http:HttpClient){}
  baseUrl = 'https://localhost:7169/api/Authentication'
  
  login(loginDto:ILogin):Observable<ILogin>{
    return this.http.post<ILogin>(`${this.baseUrl}/Login`, loginDto);
  }
  register(registerDto:IRegister):Observable<IRegister>{
    return this.http.post<IRegister>(`${this.baseUrl}/Register`, registerDto);
  }
}
