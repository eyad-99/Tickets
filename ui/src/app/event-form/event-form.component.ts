import { Component, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EventCreateDto } from '../../models/event-create-dto';
import { Router } from '@angular/router';
import { EventsService } from '../../services/events.service';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrl: './event-form.component.css',
  encapsulation: ViewEncapsulation.None // Disable View Encapsulation

})
export class EventFormComponent {


  event: EventCreateDto = {
    
    name: '',
    description: '',
    date: new Date(),
    numberOfTickets: 0,
    price: 0
  };
  errorMessage: string = '';


  constructor(private eventsService: EventsService,private router: Router) { }

  onSubmit(form: NgForm) {
    if (form.valid) {
      console.log('Event Created:', this.event);
      this.eventsService.addEvent(this.event).subscribe(
        response => {
          console.log('Event successfully created:', response);
          form.reset();
          this.resetEvent();
          this.router.navigate(['/events']);
        },
        error => {
          console.error('Error creating event:', error);
          this.errorMessage = this.getErrorMessage(error);
          console.error('displayed:', this.errorMessage);


        }
      );
    }
    else
    {
      console.log('form not valid', );

    }
  }
  resetEvent() {
    this.event = {
      name: '',
      description: '',
      date: new Date(),
      numberOfTickets: 0,
      price: 0
    };
    this.errorMessage = '';

  }

  private getErrorMessage(error: any): string {
    if (error && error.error) {
      if (typeof error.error === 'string') {
        // If error is a string, return it directly
        return error.error;
      } else if (typeof error.error === 'object') {
        // If error is an object, try to extract error messages
        const errorObject = error.error;
        if (errorObject.errors) {
          // If errors are structured, extract them
          const messages: string[] = [];
          for (const key in errorObject.errors) {
            if (Array.isArray(errorObject.errors[key])) {
              messages.push(...errorObject.errors[key]);
            }
          }
          return messages.join(' ');
        } else if (errorObject.message) {
          // If there's a single error message, return it
          return errorObject.message;
        }
      }
    }
    // If error format is unexpected, return a generic message
    return 'An error occurred while creating the event. Please try again.';
  }
  

}
