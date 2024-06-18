import { Component } from '@angular/core';
import { LoginRequestDto } from '../../models/login-request-dto';
import { AuthinticateService } from '../../services/authinticate.service';
import { Loginresponse } from '../../models/loginresponse';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginRequest: LoginRequestDto = {
    Email: '',
    Password: ''
  };
  loginResponse: Loginresponse | undefined;
  errorMessage: string | undefined;


  constructor(private authService: AuthinticateService, private router: Router) { }

  onSubmit() {
    if (this.loginRequest.Email && this.loginRequest.Password) {
      console.log('Login request', this.loginRequest);
      this.authService.login(this.loginRequest).subscribe(
        (response: Loginresponse) => {
          this.loginResponse = response;
          console.log('Login successful', this.loginResponse);
          console.error('Login failed', this.errorMessage);


          // Store the login response in local storage
          localStorage.setItem('loginResponse', JSON.stringify(this.loginResponse));
          localStorage.setItem('jwtToken', this.loginResponse.token);

          console.log(localStorage.getItem('loginResponse'));
          console.error('Login failed', this.errorMessage);


          // Navigate to the events component
          //this.router.navigate(['/events']);

          if (this.loginResponse.roles.includes('admin')) {
            // Navigate to the events component if the user is an admin
            this.router.navigate(['/events']);
          } else {
            // Navigate to a different route if the user is not an admin
            this.router.navigate(['/normal']);
          }
        },
        error => {
          console.error('Login failed', error);
          this.errorMessage = 'Login failed. Please check your credentials and try again.';
          console.error('Login failed', this.errorMessage);

        }
      );
    } else {
      console.log('Form is invalid');
      this.errorMessage = 'Please fill in both email and password.';
      console.error('Login failed', this.errorMessage);

    }
  }

}
