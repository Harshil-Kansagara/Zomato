import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Debuger } from '../service/debug.service';
import { HttpClient } from '@angular/common/http';
import * as jwt_decode from 'jwt-decode';

const cmp: string = "Admin Component";

@Component({
  templateUrl: './admin.component.html'
})

export class AdminComponent implements OnInit {
  pageTitle = "Zomato Admin"
  token: string;
  userName: string;

  constructor(private router: Router, private http: HttpClient, private debug: Debuger) {
    this.debug.loadDebuger(cmp, "constructor", "created", []);
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log(this.token, "--Token is not null");
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
      this.router.navigateByUrl('admin/restaurant');
    }
    else {
      console.log("Token is null")
    }
  }

  logOut() {
    localStorage.removeItem('token');
    window.location.href = '/admin';
  }
}
