import { AuthServices } from './../../Services/auth-services';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IResetPassword } from '../../Models/ireset-password';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reset-password',
  imports: [ReactiveFormsModule],
  templateUrl: './reset-password.html',
  styleUrl: './reset-password.css'
})
export class ResetPassword {
constructor(private authServices: AuthServices, private route:ActivatedRoute){}
  resetForm = new FormGroup({
    newPassword: new FormControl("",[Validators.required])
  })
  resetPassword = {} as IResetPassword;
  
  ResetPassword(){
    
    event?.preventDefault();
    console.log(this.resetForm.value);
    this.resetPassword.newPassword= this.resetForm.controls['newPassword'].value??"";
    this.route.queryParamMap.subscribe(params=>{
      this.resetPassword.code=params.get('code')??""
      this.resetPassword.email=params.get('email')??""
    });

    console.log(this.resetPassword);
    this.authServices.resetPassword(this.resetPassword).subscribe({
      next:(res)=> console.log(res)
    });
  }
}
