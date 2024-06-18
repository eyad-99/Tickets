import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EventsService } from '../../services/events.service';
import { Event } from '../../models/event';

@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css'],
  encapsulation: ViewEncapsulation.None // Disable View Encapsulation
})
export class EventEditComponent implements OnInit {
  event: Event = {
    id: 0,
    name: '',
    description: '',
    date: '',
    numberOfTickets: 0,
    remainTickets: 0,
    price: 0
  };
  errorMessage: string = '';
  eventDate: string = '';
  eventTime: string = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private eventsService: EventsService
  ) { }

  ngOnInit(): void {
    const eventIdStr = this.route.snapshot.paramMap.get('id');
    if (eventIdStr) {
      const eventId = +eventIdStr; // Convert the string to a number
      this.eventsService.getEventById(eventId).subscribe(
        (event: Event) => {
          this.event = event;
          const eventDate = new Date(this.event.date); // Convert string to Date object
          this.eventDate = this.getFormattedDate(eventDate);
          this.eventTime = this.getFormattedTime(eventDate);
        },
        (error: any) => this.errorMessage = 'Error fetching event details'
      );
    }
  }

  getFormattedDate(date: Date): string {
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    const year = date.getFullYear();
    return `${year}-${month}-${day}`;
  }

  getFormattedTime(date: Date): string {
    const hours = ('0' + date.getHours()).slice(-2);
    const minutes = ('0' + date.getMinutes()).slice(-2);
    return `${hours}:${minutes}`;
  }

  onDateChange(event: any) {
    this.eventDate = event.target.value;
    this.combineDateTime();
  }

  onTimeChange(event: any) {
    this.eventTime = event.target.value;
    this.combineDateTime();
  }

  combineDateTime() {
    const [year, month, day] = this.eventDate.split('-');
    const [hours, minutes] = this.eventTime.split(':');
    const combinedDate = new Date(
      parseInt(year, 10),
      parseInt(month, 10) - 1,
      parseInt(day, 10),
      parseInt(hours, 10),
      parseInt(minutes, 10)
    );
    this.event.date = combinedDate.toISOString(); // Convert to ISO string
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.combineDateTime(); // Ensure date and time are combined before submission
      this.eventsService.updateEvent(this.event).subscribe(
        response => {
          this.router.navigate(['/events']);
        },
        error => {
          this.errorMessage = 'Error updating event';
        }
      );
    }
  }
}
