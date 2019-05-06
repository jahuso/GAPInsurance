import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent {

  constructor(private auth: AuthService) {
  }
  login() {
    this.auth.login();
  }

  logout() {
    this.auth.logout();
  }

}
