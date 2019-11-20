import { Injectable } from '@angular/core';
import { Register } from '../model/register';
import { HttpClient } from '@angular/common/http';
import { Login } from '../model/login';

@Injectable({ providedIn: 'root' })
export class AccountService {

  baseUrl: string = "api/user/";

  constructor(private http: HttpClient) { }

  public Login(login: Login) {
    return this.http.post(this.baseUrl + "login", login);
  }

  //public Loginlogin: Login) {
  //  return this.http.post(this.baseUrl + "login", login);
  //}

  public Register(register: Register) {
    return this.http.post(this.baseUrl + "register", register);
  }

  public GetUserData(userId: string) {
    return this.http.get(this.baseUrl + userId);
  }

  public getUsersList(userId: string) {
    return this.http.get(this.baseUrl + "users/" + userId);
  }

  intializeRegister(): Register {
    return {
      UserName: '',
      UserMobileNumber: '',
      UserEmailAddress: '',
      UserPassword: '',
      UserRole: ''
    }
  }

  initializeLogin(): Login {
    return {
      UserEmailAddress: '',
      UserPassword: ''
    }
  }
}
