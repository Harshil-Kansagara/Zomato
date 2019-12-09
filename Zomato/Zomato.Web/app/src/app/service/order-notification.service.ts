import { Injectable, EventEmitter } from "@angular/core";
import { Order } from '../model/order';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

Injectable({ providedIn: "root" })
export class OrderNotificationService {
  orderReceived = new EventEmitter<Order>();

  connectionEstablished = new EventEmitter<Boolean>();
  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  sendOrder(order: Order) {
    this._hubConnection.invoke('NewOrder', order);
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:59227/OrderHub")
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
    this._hubConnection.on('OrderReceived', (data: any) => {
      this.orderReceived.emit(data);
    });
  }
}
