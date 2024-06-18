import { Component, ViewEncapsulation } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { Event } from '../../models/event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrl: './events.component.css',
  encapsulation: ViewEncapsulation.None // Disable View Encapsulation

})
export class EventsComponent {
  deleteRecord(event: Event): void {
    const confirmed = window.confirm('Are you sure you want to delete this event?');
    if (confirmed) {
      this.eventsService.deleteEvent(event.id).subscribe(() => {
        this.loadEvents();
      });
    }
  }
  
updateRecord(event: Event) {
  this.router.navigate(['/events/edit', event.id]);
}
  events: Event[] = [];

  constructor(private eventsService: EventsService,private router: Router) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents(): void {
    this.eventsService.getEvents().subscribe(
      (data: Event[]) => {
        this.events = data;
      },
      (error) => {
        console.error('Error fetching events', error);
      }
    );
  }




  navigateToCreateEvent() {
    this.router.navigate(['/create-event']);
  }

}
