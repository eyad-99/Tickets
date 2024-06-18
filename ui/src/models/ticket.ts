
import { Event } from "./event";

export interface Ticket {
    id: number;
  event: Event;
  eventId: number;
  reserveDate: Date;
  userId: number;
}
