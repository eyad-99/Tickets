import { Component, ViewEncapsulation } from '@angular/core';
import { AuthinticateService } from '../../services/authinticate.service';
import { RegisterRequestDto } from '../../services/register-request-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
  encapsulation: ViewEncapsulation.None // Disable View Encapsulation

})
export class RegisterComponent {
  registerDto: RegisterRequestDto = {
    email: '',
    password: ''
  };
  errorMessage: string | null = null; // Add property to store error message


  constructor(private authService: AuthinticateService, private router: Router) {}

  register(): void {
    this.authService.register(this.registerDto).subscribe(
      () => {
        console.log('Registration successful');
        // Optionally, navigate to a different page or show a success message
        this.router.navigate(['/login']);  // Navigate to the login page

      },
      error => {
        console.error('Registration failed', error);
        // Optionally, show an error message to the user
        this.errorMessage = 'Registration failed. Please try again.';  // Set error message

      }
    );
  }
}
