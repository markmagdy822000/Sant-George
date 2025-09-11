import { IResetPassword } from './../Models/ireset-password';
import { IForgotPasswordDTO } from '../Models/iforgotPasswordDTO';
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

  forgotPassword(forgotPasswordDTO:IForgotPasswordDTO):Observable<IForgotPasswordDTO>{
    return this.http.get<IForgotPasswordDTO>(`${this.baseUrl}/forgot-password?email=${forgotPasswordDTO.email}`);
  }

  resetPassword(IResetPassword:IResetPassword):Observable<any>{
    return this.http.post<any>(`${this.baseUrl}/ResetPassword`, IResetPassword);
  }

  testAuth():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/secured`);
  }

  getRefreshToken(oldToken?:string):Observable<any>{
    if(oldToken == null)  oldToken=""
    console.log("oldTokenoldToke: ",oldToken);
    console.log('req snet from auth service: ')
    console.log(`${this.baseUrl}/newTokens, ${oldToken}`)
    return this.http.post<any>(`${this.baseUrl}/newTokens?`,{oldToken}, {withCredentials : true});
  }
}
