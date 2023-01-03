
import { UserRegistrationRequest } from './../_interfaces/Registration/UserRegistrationRequest.model'; 
import { UserRegistrationResponse } from './../_interfaces/Registration/UserRegistrationResponse.model';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { EnvironmentUrlService } from './environment-url.service';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public registerUser = (route: string, body: UserRegistrationRequest) => {
    return this.http.post<UserRegistrationResponse>(`${this.envUrl.urlAddress}/${route}`, body);
  }
}