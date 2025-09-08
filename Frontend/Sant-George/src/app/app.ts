import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {  Login } from "./Components/login/login";
import {  Register } from "./Components/register/register";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Login, Register],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Sant-George';
}
