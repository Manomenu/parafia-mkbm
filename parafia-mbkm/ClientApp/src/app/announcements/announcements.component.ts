import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  styleUrls: ['./announcements.component.css']
})
export class AnnouncementsComponent {
  public announcements: Announcement[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe(params => console.log(params));
    http.get<Announcement[]>(baseUrl + 'api/announcement').subscribe({
      next: (result) => {
        this.announcements = result;
        console.log(result);
      }, error: (err) => {
        console.error(err);
      }
    });
  }

  onClick(title: string, date: string, id: number) {
    this.router.navigate(['api/announcement', title, date, id]);
  } 
}

// change date to Date type!!!!
interface Announcement {
  id: number;
  title: string;
  date: string;
  content: string;
}
