import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class StandService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public GetStands = (route: string) => {
    return this.http.get(this.GetCompleteRoute(route));
  }

  private GetCompleteRoute(route : string) : string{
    return `${this.envUrl.urlAddress}/${route}`;
  }
}
