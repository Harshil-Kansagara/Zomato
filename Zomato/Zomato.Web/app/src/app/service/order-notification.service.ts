import { Injectable, EventEmitter } from "@angular/core";
import { Order } from '../model/order';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ToastrService } from 'ngx-toastr';

Injectable({ providedIn: "root" })
export class OrderNotificationService {
  orderReceived = new EventEmitter<Order>();
  token: string;

  connectionEstablished = new EventEmitter<Boolean>();
  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  constructor() {
    this.getUserId();
    this.createConnection();
    this.startConnection();
    this.registerOnServerEvents();
  }

  //sendOrder(order: Order) {
  //  this._hubConnection.invoke('NewOrder', order);
  //}

  public createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:59227/OrderHub", { accessTokenFactory: () => this.token})
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function () { this.startConnection(); }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('OrderReceived', (data: Order) => {
      this.orderReceived.emit(data);
    });
  }

  private getUserId(): void {
    this.token = localStorage.getItem('token');
  }
}
