import { Component, signal,inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Nav } from "../Layout/nav/nav";
import { AccountService } from '../Core/services/account-service';
import { Home } from "../Features/home/home";
import { User } from '../types/user';



@Component({
  selector: 'app-root',
  imports: [Nav, Home],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App implements OnInit {

  private accountService = inject(AccountService);

  private http = inject(HttpClient);
  protected readonly title = "Dating App";

  protected members = signal<User[]>([]);

  async ngOnInit(): Promise<void> {
    this.members.set(await this.getMembers());
    this.setCurrentUser();

  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if(!userString){
      return;
    }

    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user); 

  }

  async getMembers() {
    try {
      return lastValueFrom(this.http.get<User[]>('https://localhost:5001/api/members'));
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

}
