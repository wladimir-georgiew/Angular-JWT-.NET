import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RequestHandlerService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  private GetCompleteRoute(route : string) : string{
    return `${this.envUrl.urlAddress}/${route}`;
  }

  public HttpGet = (route: string) => {
    return this.http.get(this.GetCompleteRoute(route));
  }

  public HttpPost = (route: string, body: any) => {
    return this.http.post(this.GetCompleteRoute(route), body);
  }

}
