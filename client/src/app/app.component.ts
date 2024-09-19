import { NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

interface User {
  id: number;
  userName: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'DatingApp';
  users: User[] = []; // Define users as an array of User type

  ngOnInit(): void {
    this.http.get<User[]>('http://localhost:5001/api/users').subscribe({
      next: response => {
        this.users = response;
        console.log(this.users);  // Check if users are being fetched
      },
      error: error => console.error('Error fetching users', error),
      complete: () => console.log('Request has completed')
    });
  }
}
