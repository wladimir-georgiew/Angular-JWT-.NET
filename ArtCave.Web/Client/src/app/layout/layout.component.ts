import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  showFiller = false;
  public isUserAuthenticated: boolean;
  
  constructor(private authService: AuthenticationService, private router : Router) {
    this.authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }

  ngOnInit(): void {
    this.authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }
  
  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }

  public isUserAdmin() : boolean {
    return this.authService.getUserRole() === 'Admin';
  }

}