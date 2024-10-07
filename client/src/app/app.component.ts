import { NgFor } from '@angular/common';
import { Component, inject, Input, input, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_service/account.service';
import { ThisReceiver } from '@angular/compiler';
import { HomeComponent } from "./home/home.component";

interface User {
  id: number;
  userName: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor, NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private accountService = inject(AccountService);
  @Input() usersFromHomeComponent:any;  

  ngOnInit(): void {
 
    this.setCurrentUser();
  }

  setCurrentUser(){
    const useString = localStorage.getItem('user');
    if(!useString) return;
    const user = JSON.parse(useString);
    this.accountService.currentUser.set(user);
  }

  
  }
