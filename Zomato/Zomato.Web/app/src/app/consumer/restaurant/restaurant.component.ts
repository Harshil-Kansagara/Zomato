import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Login } from '../../model/login';
import { Register } from '../../model/register';
import { AccountService } from '../../service/account.service';
import * as jwt_decode from 'jwt-decode';
import { RestaurantService } from '../../service/restaurant.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})

export class RestaurantComponent implements OnInit {
  registerToken: boolean = false;
  register: Register;
  login: Login;
  promise: Subscription;
  token: string;
  decode_token: string;
  userName: string;

  constructor(private toastr: ToastrService, private accountService: AccountService, private restaurantService: RestaurantService, private router: Router) { }

  ngOnInit() {
    this.register = this.accountService.intializeRegister();
    this.login = this.accountService.initializeLogin();
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log("Token is not null: ", this.token);
      this.decode_token = jwt_decode(this.token)
      if (this.decode_token['UserRole'] == "user") {
        this.userName = this.decode_token['UserName'];
      }
    } else {
      console.log("Token is null");
    }

    this.loadRestaurantList();
  }

  ngOnDestroy(): void {
    this.promise.unsubscribe();
  }

  loadRestaurantList() {

  }

  reg(): void {
    this.registerToken = true;
  }
  log(): void {
    this.registerToken = false;
  }

  registerUser(): void {
    this.register.UserRole = "user";
    this.promise = this.accountService.Register(this.register).subscribe(
      (result: any) => {
        if (result.succeeded) {
          this.toastr.success("Register Successfully");
          this.register = this.accountService.intializeRegister();
          this.registerToken = false;
        }
        else {
          for (let i = 0; i < result.errors.length; i++) {
            this.toastr.error(result.errors[i].description);
          }
        }
      }, err => {
        console.log(err);
      }
    );
  }

  loginUser(): void {
    console.log(this.login);
    this.promise = this.accountService.Login(this.login).subscribe(
      (res: any) => {
        if (res != null) {
          console.log(res.token);
          this.decode_token = jwt_decode(res.token);
          if (this.decode_token['UserRole'] == 'user') {
            localStorage.setItem('token', res.token);
            window.location.reload();
            this.toastr.success("Login Successful");
            //window.location.href = "admin/restaurant";
          } else {
            this.toastr.error("You don't have priviledge to access this page");
          }
        }
      }, err => {
        if (err.status == 400) {
          this.toastr.error('Incorrect Username or Password.', 'Authentication Failed.');
        } else {
          console.log(err);
        }
      }
    );
  }

  logoutUser() {
    localStorage.removeItem('token');
    window.location.reload();
  }
}
