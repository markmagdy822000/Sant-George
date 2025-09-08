import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthServices } from '../../Services/auth-services';
import { IForgotPasswordDTO } from '../../Models/iforgotPasswordDTO';
import { validateHeaderName } from 'http';

@Component({
  selector: 'app-forgot-password',
  imports: [ReactiveFormsModule],
  templateUrl: './forgot-password.html',
  styleUrl: './forgot-password.css'
})
export class ForgotPassword {
constructor(private authServices: AuthServices){}
sub?:any;  
ngOnDestroy(){
  this.sub?.unsubscribe();
}
forgotForm = new FormGroup({
  email: new FormControl('', [Validators.email,Validators.required])
});

forgetPassword(){
  console.log(this.forgotForm.value);
  event?.preventDefault();
  this.sub =  this.authServices.forgotPassword(this.forgotForm.value as IForgotPasswordDTO).subscribe({
    next:(res)=>{
      console.log(res);
    },
    error:(err)=>console.log(err)
  
  });

}
}
