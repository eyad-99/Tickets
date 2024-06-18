import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginRequestDto } from '../models/login-request-dto';
import { environment } from '../environments/environment';
import { Loginresponse } from '../models/loginresponse';
import { Observable, map } from 'rxjs';
import { RegisterRequestDto } from './register-request-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthinticateService {
  private apiUrl = environment.apiUrl;  // Use the environment variable


  constructor(private http: HttpClient) { }  // Inject HttpClient here

  // Example method to demonstrate HTTP GET request
  login(logindto: LoginRequestDto) {
    return this.http.post<Loginresponse>(`${this.apiUrl}/Auth/login`, logindto).pipe(
      map((response: { email: string; roles: string[]; token: string; }) => new Loginresponse(response.email, response.roles, response.token))
    );  }

    register(registerDto: RegisterRequestDto): Observable<void> {
      return this.http.post<void>(`${this.apiUrl}/Auth/register`, registerDto);
    }




}
