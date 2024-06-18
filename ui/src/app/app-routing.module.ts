import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EventsComponent } from './events/events.component';
import { EventFormComponent } from './event-form/event-form.component';
import { EventEditComponent } from './event-edit/event-edit.component';
import { UsercomponentComponent } from './usercomponent/usercomponent.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'events', component: EventsComponent},
  { path: 'normal', component: UsercomponentComponent},

  { path: 'create-event', component: EventFormComponent },
  { path: 'events/edit/:id', component: EventEditComponent }, // Edit route


  { path: '', redirectTo: '/login', pathMatch: 'full' } // Default route
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
