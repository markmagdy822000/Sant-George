import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { Login } from './Components/login/login';
import { register } from 'module';
import { Register } from './Components/register/register';
import { ForgotPassword } from './Components/forgot-password/forgot-password';
import { ResetPassword } from './Components/reset-password/reset-password';

export const routes: Routes = [
    {path:'', redirectTo:'register', pathMatch:'full'},
    {path:'login', component:Login},
    {path:'register', component:Register},
    {path:'forgot-password', component:ForgotPassword},
    {path: 'reset-password', component: ResetPassword }

];
