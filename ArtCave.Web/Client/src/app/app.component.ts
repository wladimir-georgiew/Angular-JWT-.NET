import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';

  constructor(private authService: AuthenticationService){}
  
  ngOnInit(): void {
    if(this.authService.isUserAuthenticated())
      this.authService.sendAuthStateChangeNotification(true);
  }
}
