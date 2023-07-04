import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  styleUrls: ['./announcements.component.css']
})
export class AnnouncementsComponent {
  public announcements: Announcement[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Announcement[]>(baseUrl + 'announcements').subscribe({
      next: (result) => {
        this.announcements = result;
      }, error: (err) => {
        console.error(err);
      }
    });
  }
}

interface Announcement {
  title: string;
  date: string;
  content: string;
}
