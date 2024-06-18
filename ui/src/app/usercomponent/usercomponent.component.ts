import { Component } from '@angular/core';
import { Ticket } from '../../models/ticket';
import { TicketsService } from '../../services/tickets.service';
import { Event } from '../../models/event';

@Component({
  selector: 'app-usercomponent',
  templateUrl: './usercomponent.component.html',
  styleUrl: './usercomponent.component.css'
})
export class UsercomponentComponent {
  
  userTickets: Ticket[] = [];
  notAssignedEvents: Event[] = [];
  errorMessage: string = '';

  constructor(private ticketsService: TicketsService) {}

  ngOnInit() {
    this.loadUserTickets();
    this.loadNotAssignedEvents();
  }

  loadUserTickets() {
    this.ticketsService.getUserTickets().subscribe(
      (tickets) => {
        this.userTickets = tickets;
      },
      (error) => {
        console.error('Failed to load user tickets', error);
        if (error.status === 500) {
          console.error('Server error: ', error.error);
        }
      }
    );
  }

  loadNotAssignedEvents() {
    this.ticketsService.getEventsNotAssignedToUser().subscribe(
      (events) => {
        this.notAssignedEvents = events;
      },
      (error) => {
        console.error('Failed to load events not assigned to user', error);
        this.errorMessage = 'Failed to load events not assigned to user';
      }
    );
  }

  createTicket(eventId: number): void {
    this.ticketsService.createTicket(eventId).subscribe(
      (newTicket: Ticket) => {
        console.log('Ticket created:', newTicket);
        this.loadUserTickets(); // Reload tickets to reflect the new ticket
        this.loadNotAssignedEvents(); // Reload tickets to reflect the new ticket

      },
      error => {
        console.error('Error creating ticket:', error);
      }
    );
  }

  deleteTicket(ticketId: number): void {
    this.ticketsService.deleteTicket(ticketId).subscribe(
      (newTicket: Ticket) => {
        console.log('Ticket deleted:', newTicket);
        this.loadNotAssignedEvents(); // Reload tickets to reflect the new ticket
        this.loadUserTickets(); // Reload tickets to reflect the new ticket

      },
      error => {
        console.error('Error creating ticket:', error);
      }
    );
  }


  isEventDatePassed(eventDate: string): boolean {
    const today = new Date();
    const eventDateObj = new Date(eventDate);
    return eventDateObj < today;
  }

}
