import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  templateUrl: './single-announcement.component.html',
  styleUrls: ['./single-announcement.component.css']
})
export class SingleAnnouncementComponent {
  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe( params => console.log(params));
  }
}
