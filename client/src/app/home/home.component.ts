import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  //to be called in the ngOnInit
  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe(users => this.users = users); //getting user form the api
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}

