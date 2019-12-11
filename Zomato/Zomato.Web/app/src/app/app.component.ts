import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import * as jwt_decode from 'jwt-decode';
import { OrderNotificationService } from './service/order-notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

  token: string;
  //token: string[] = [];
  //orders: any[] = [];
  //constructor(private orderNotificationService: OrderNotificationService, private _ngZone: NgZone) {
  //  this.subscribeToEvents();
  //}

  //private subscribeToEvents(): void {

  //  this.orderNotificationService.orderReceived.subscribe((order: any) => {
  //    this._ngZone.run(() => {
  //      //this.orders.push(order);
  //      console.log(order);
  //    });
  //  });
  //}

  ngOnInit(): void {
    this.getUserId();
    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl("http://localhost:59227/notify", { accessTokenFactory: () => this.token })
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
    this.token = localStorage.getItem('token');
  }
}
