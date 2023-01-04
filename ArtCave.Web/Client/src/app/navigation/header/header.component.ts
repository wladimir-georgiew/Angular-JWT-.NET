import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from './../../services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public isUserAuthenticated: boolean;
  @Output() public sidenavToggle = new EventEmitter();
  
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

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }

  public isUserAdmin() : boolean {
    return this.authService.getUserRole() === 'Admin';
  }
}