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

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe( params => console.log("params : ", params));
      http.get<Announcement[]>(baseUrl + 'api/announcement').subscribe({
      next: (result) => {
        this.announcements = result;
        console.log(result);
      }, error: (err) => {
        console.error(err);
      }
    });
  }

  onClick(title: string, date: Date, id: number) {
    this.http.get<Announcement[]>(this.baseUrl + 'api/announcement/' + id).subscribe({
      next: (result) => {
        if (result == null) {
          this.router.navigate([this.baseUrl]);
        } else {
          this.router.navigate(['api/announcement', title, date, id]);
         }
      }, error: (err) => {
        console.error(err);
      }
    });
  } 
}

// change date to Date type!!!!
interface Announcement {
  id: number;
  title: string;
  date: Date;
  content: string;
}
