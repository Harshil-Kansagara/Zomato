import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})

export class AuthUserGuard implements CanActivate {

  token_user; decode_token; userName; searchText; userId; role: string = "";

  constructor(private router: Router) {
  }

  canActivate(next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    this.token_user = localStorage.getItem('token_user');
    if (this.token_user != null) {
      this.decode_token = jwt_decode(this.token_user)
      if (this.decode_token['UserRole'] == "user") {
        return true;
      } else {
        return false;
      }
    } else {
      this.router.navigateByUrl('');
      return false;
    }
  }

}
