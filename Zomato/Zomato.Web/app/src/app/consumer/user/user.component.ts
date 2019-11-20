import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActivatedRoute, Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { AccountService } from '../../service/account.service';
import { Subscription } from 'rxjs';
import { Register } from '../../model/register';

@Component({
  templateUrl: 'user.component.html',
  styleUrls: ['user.component.css']
})

export class UserComponent implements OnInit, OnDestroy {

  token_user; userId; decode_token: string;
  userSubscription: Subscription;
  user: Register;

  constructor(private accountService: AccountService, private router:Router) {
  }

  ngOnInit(): void {
    this.getUserId();
    this.getUserData();
  }

  ngOnDestroy(): void {
    if (this.userSubscription) {
      this.userSubscription.unsubscribe();
    }
  }

  getUserId(): void {
    this.token_user = localStorage.getItem('token_user');
    if (this.token_user != null) {
      this.decode_token = jwt_decode(this.token_user);
      if (this.decode_token['UserRole'] == "user") {
        this.userId = this.decode_token['UserId'];
      }
    }
  }

  getUserData(): void {
    this.user = this.accountService.intializeRegister();
    this.userSubscription = this.accountService.GetUserData(this.userId).subscribe(
      (res) => {
        if (res != null) {
          this.user = res as Register;
          console.log(this.user);
        }
      }
    );
  }

  logoutUser() {
    localStorage.removeItem('token_user');
    //window.location.reload();
    this.router.navigateByUrl("");
  }
}
