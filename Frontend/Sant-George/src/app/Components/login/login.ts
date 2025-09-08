import { AuthServices } from './../../Services/auth-services';
import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ILogin } from '../../Models/ilogin';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login implements OnDestroy{
constructor(private authServices: AuthServices){}
sub?:any;  
ngOnDestroy(): void {
  this.sub?.unsubscribe();
  }
  loginForm = new FormGroup({
     email: new FormControl('', Validators.email),
     password: new FormControl('', Validators.required),
     rememberMe: new FormControl(false)
  });

  login(){
    console.log(this.loginForm.value);
    event?.preventDefault();
    this.sub =  this.authServices.login(this.loginForm.value as ILogin).subscribe({
      next:(res)=>{
        localStorage.setItem('token', res.token??"");
        localStorage.setItem('userId', res.userId??"");
        localStorage.setItem('email', res.email??"");
      },
      error:(err)=>console.log(err)
    });
  }

}
