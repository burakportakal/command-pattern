import { Component } from '@angular/core'
import { EventService } from 'src/app/events/shared/event.service';
import { ToastrService } from 'src/app/common/toastr.service';
import { ActivatedRoute } from '@angular/router';
import { IEvent } from './shared';
import { HttpClient } from '@angular/common/http';

@Component({
  template: `
  <div>
    <h1>Upcoming Angular Events</h1>
    <hr/>
    <div class="row">
    <div *ngFor="let event of events" class="col-md-5">
      <event-thumbnail  (click)="handleThumbnailClick(event.name)" [event]="event"></event-thumbnail>
    </div>
  </div>
  `
})
export class EventsListComponent {
  events:IEvent[]

  constructor(private eventService: EventService, private toastr: ToastrService,private router:ActivatedRoute,private httpService: HttpClient) {
    
  }

  ngOnInit() {
  this.getEvents();
   /*this.eventService.subject2.subscribe(() => {
    this.getEvents();
   })*/
   this.httpService.get("https://www.tcmb.gov.tr/kurlar/today.xml").toPromise().then((data) => {
    console.log(data);
   })
  }

  getEvents(){
    this.eventService.getEvents().subscribe((events) => {
      this.events = events;
     })
  }

  handleThumbnailClick(eventName) {
    this.toastr.success(eventName)
  }
}