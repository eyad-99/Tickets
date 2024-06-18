import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Event } from '../models/event';
import { EventCreateDto } from '../models/event-create-dto';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  private apiUrl = environment.apiUrl;  // Use the environment variable

  constructor(private http: HttpClient) { }  // Inject HttpClient here

  private getHeaders() {
    const token = localStorage.getItem('jwtToken');
    return new HttpHeaders({
      Authorization: `Bearer ${token}`
    });
  }

  getEvents(): Observable<Event[]> {
    const headers = this.getHeaders();
    return this.http.get<Event[]>(`${this.apiUrl}/Events`, { headers });
  }

  addEvent(eventobj: EventCreateDto): Observable<Event> {
    const headers = this.getHeaders();
    return this.http.post<Event>(`${this.apiUrl}/Events`, eventobj, { headers });
  }

  getEventById(id: number): Observable<Event> {
    const headers = this.getHeaders();
    return this.http.get<Event>(`${this.apiUrl}/Events/${id}`, { headers });
  }

  updateEvent(event: Event): Observable<Event> {
    const headers = this.getHeaders();
    return this.http.put<Event>(`${this.apiUrl}/Events/${event.id}`, event, { headers });
  }

  deleteEvent(id: number): Observable<void> {
    const headers = this.getHeaders();
    return this.http.delete<void>(`${this.apiUrl}/Events/${id}`, { headers });
  }
}