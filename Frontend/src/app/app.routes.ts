import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { Login } from './Components/login/login';
import { register } from 'module';
import { Register } from './Components/register/register';

export const routes: Routes = [
    {path:'', redirectTo:'register', pathMatch:'full'},
    {path:'login', component:Login},
    {path:'register', component:Register}

];
