import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IRegister } from '../../Models/iregister';
import { AuthServices } from '../../Services/auth-services';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register implements OnDestroy {
  ngOnDestroy(): void {
  this.sub?.unsubscribe();
  }
  constructor(private authServices: AuthServices){}
  
  sub!:any;
    registerForm = new FormGroup({
     username : new FormControl('', Validators.required),
     email: new FormControl('', Validators.email),
     password: new FormControl('', Validators.required),
     class: new FormControl(0, Validators.required),
     address: new FormControl('', Validators.required),
     gender: new FormControl('', Validators.required),
  });

  register(){
    console.log(this.registerForm.value);
    event?.preventDefault();
    this.sub = this.authServices.register(this.registerForm.value as IRegister).subscribe({
      next:(res)=>console.log(res),
      error:(err)=>console.log(err)
    });
  }


}
