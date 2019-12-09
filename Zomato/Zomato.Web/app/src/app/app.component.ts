import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import * as jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

  token_user;decode_token: string;

  constructor() { }

  ngOnInit(): void {
    this.getUserId();
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl("http://localhost:59227/notify", { accessTokenFactory: () => this.token_user })
      .build();

    connection.start().then(function () {
      console.log('Connected!');
    }).catch(function (err) {
      return console.error(err.toString());
    });

    connection.on("BroadcastMessage", (data: any) => {
      console.log("BroadCastData:")
      console.log(data);
    });
  }

  getUserId(): void {
    this.token_user = localStorage.getItem('token_user');
    if (this.token_user != null) {
      this.decode_token = jwt_decode(this.token_user);
    }
  }
}
