import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { Debuger } from '../service/debug.service';
import { HttpClient } from '@angular/common/http';
import * as jwt_decode from 'jwt-decode';
import { Order } from '../model/order';
import { ToastrService } from 'ngx-toastr';
import { OrderNotificationService } from '../service/order-notification.service';

const cmp: string = "Admin Component";

@Component({
  templateUrl: './admin.component.html'
})

export class AdminComponent implements OnInit {
  pageTitle = "Zomato Admin"
  token: string;
  userName: string;
  userToken: boolean = false;
  orders: Order[] = [];
  notificationCount: number = 0;

  constructor(private router: Router, private http: HttpClient, private orderNotificationService: OrderNotificationService,
              private _ngZone: NgZone, private toastr: ToastrService) {
    this.subscribeToEvents();
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log(this.token, "--Token is not null");
      let decode_token = jwt_decode(this.token);
      if (decode_token['UserRole'] == "admin") {
        this.userName = decode_token['UserName'];
        this.userToken = true;
        this.router.navigateByUrl('admin/restaurant');
      } else {
        this.userToken = false;
      }
    }
    else {
      console.log("Token is null")
    }
  }

  private subscribeToEvents(): void {

    this.orderNotificationService.orderReceived.subscribe((order: Order) => {
      this._ngZone.run(() => {
        order.restaurantName = order.restaurantName.replace('%20', ' ');
        this.orders.push(order);
        this.toastr.success(order.restaurantName + " has order");
        console.log("BroadCast Data");
        console.log(order);
        this.notificationCount = this.orders.length;
        //console.log("Order count: " + this.orders.length);
      });
    });
  }

  logOut() {
    localStorage.removeItem('token');
    window.location.href = '/admin';
  }
}
