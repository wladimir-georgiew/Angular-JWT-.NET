import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Subject } from 'rxjs';

import { UserRegistrationRequest } from './../_interfaces/Registration/UserRegistrationRequest.model'; 
import { UserRegistrationResponse } from './../_interfaces/Registration/UserRegistrationResponse.model';
import { UserLoginRequest } from './../_interfaces/Login/UserLoginRequest.model';
import { UserLoginResponse } from './../_interfaces/Login/UserLoginResponse.model';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public registerUser = (route: string, body: UserRegistrationRequest) => {
    return this.http.post<UserRegistrationResponse>(this.GetCompleteRoute(route), body);
  }

  public loginUser = (route: string, body: UserLoginRequest) => {
    return this.http.post<UserLoginResponse>(this.GetCompleteRoute(route), body);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }

  private GetCompleteRoute(route : string) : string{
    return `${this.envUrl.urlAddress}/${route}`;
  }
}