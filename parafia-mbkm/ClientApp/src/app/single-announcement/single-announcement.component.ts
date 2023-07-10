import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { AnnouncementsComponent } from '../announcements/announcements.component';
import { HttpClient } from '@angular/common/http';

@Component({
  templateUrl: './single-announcement.component.html',
  styleUrls: ['./single-announcement.component.css']
})
export class SingleAnnouncementComponent {
  id: number = -1;
  announcement: Announcement | undefined;

  constructor(private route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.route.params.subscribe(params => {
      this.id = params.id;
    });
    if (this.id > 0) {
      http.get<Announcement>(baseUrl + 'api/announcement/' + this.id).subscribe({
        next: (result) => {
          this.announcement = result;
        }, error: (err) => {
          console.error(err);
        }
      });
    }
  }

  Return() {
    this.router.navigate(['api/announcement']);
  }
}

interface Announcement {
  id: number;
  title: string;
  date: Date;
  content: string;
}
