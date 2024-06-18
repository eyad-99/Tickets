import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { Ticket } from '../models/ticket';
import { Event } from '../models/event';

@Injectable({
  providedIn: 'root'
})
export class TicketsService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  private getHeaders() {
    const token = localStorage.getItem('jwtToken');
    return new HttpHeaders({
      Authorization: `Bearer ${token}`
    });
  }

  getUserTickets(): Observable<Ticket[]> {
    const headers = this.getHeaders();
    return this.http.get<Ticket[]>(`${this.apiUrl}/Tickets/user-tickets`, { headers });
  }

  getEventsNotAssignedToUser(): Observable<Event[]> {
    const headers = this.getHeaders();
    return this.http.get<Event[]>(`${this.apiUrl}/Tickets/not-assigned`, { headers });
  }
  createTicket(eventId: number): Observable<Ticket> {
    const headers = this.getHeaders();
    return this.http.get<Ticket>(`${this.apiUrl}/Tickets/create/${eventId}`,  { headers });
  }

  deleteTicket(id: number): Observable<Ticket> {
    const headers = this.getHeaders();
    return this.http.delete<Ticket>(`${this.apiUrl}/Tickets/${id}`,  { headers });
  }
}
