import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule, RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  http = inject(HttpClient);

  registerMode=false;
  users:any;

  registerToggle(){
    this.registerMode = !this.registerMode
  } 
  cancelRegisterMode(event:boolean){
    this.registerMode=event;
  }
  ngOnInit(): void {
  this.getUser();
  }
  getUser() {
    this.http.get<User[]>('http://localhost:5000/api/users').subscribe({
      next: response => {
        this.users = response;
        console.log(this.users);  
      },
      error: error => console.error('Error fetching users', error),
      complete: () => console.log('Request has completed')
    });}}
