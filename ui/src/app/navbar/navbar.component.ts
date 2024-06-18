import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(private router: Router) {}

  logout() {
    // Clear local storage
    console.log(localStorage.getItem('loginResponse'))
    localStorage.removeItem('loginResponse');
    localStorage.removeItem('jwtToken');

    console.log(localStorage.getItem('loginResponse'))



    // Optionally, clear other items related to the user session
    // localStorage.removeItem('user');
    // localStorage.removeItem('roles');

    // Navigate to the login page
    this.router.navigate(['/login']);
  }

}
