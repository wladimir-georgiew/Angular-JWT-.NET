import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({
  providedIn: 'root'
})

export class RoleGuard implements CanActivate {

  constructor(private authService: AuthenticationService, private router: Router){}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let allowedRoles = route.data['roles'] as Array<string>;
    let userRole = this.authService.getUserRole();
    let isUserAuthenticated = this.authService.isUserAuthenticated();
    
    if (isUserAuthenticated &&
        allowedRoles.includes(userRole)) {
      return true;
    }
    
    if(isUserAuthenticated){
      this.router.navigate(['/forbidden']);
    }
    else{
      this.router.navigate(['/authentication/login'], { queryParams: { returnUrl: state.url }});
    }
    
    return false;
  } 
}