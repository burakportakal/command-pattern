import { Component, OnInit } from "@angular/core";
import { EventService } from "../shared/event.service";
import { IEvent } from "../shared/event.model";
import { Location } from '@angular/common';

@Component({
    templateUrl: "./event-delete.component.html"
})
export class EventDelete implements OnInit {
    private events: IEvent[] = [];
    constructor(private eventService: EventService,private location: Location) {

    }
    ngOnInit(): void {
      this.getEvents();
    }
    deleteEvent(id: number) {
        if(this.checkDirtyState()){
        this.eventService.deleteEvent(id).toPromise<any>().then(e => {
            if (e.value.isSuccess) {
                alert("başarılı");
                this.location.back();
            }
            else{
                alert("başarısız");
            }
        });
    }
    }
    getEvents(){
        this.eventService.getEvents().toPromise().then(e => {
            this.events = e;
        });
    }
    checkDirtyState() : boolean{
          return window.confirm("Do you really want to delete this event?");
    }
}