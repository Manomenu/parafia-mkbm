import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { announcement } from './models/announcement';
import { AnnouncementDbService } from './services/announcement-db.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  styleUrls: ['./announcements.component.css']
})
export class AnnouncementsComponent {
  public announcements$!: Observable<announcement[]>;
  public idRef: number = -1;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private announcementDbService: AnnouncementDbService
  ) {
/*    this.route.params.subscribe(params => console.log("params : ", params));
      http.get<Announcement[]>(baseUrl + 'api/announcement').subscribe({
      next: (result) => {
        this.announcements = result;
        console.log(result);
      }, error: (err) => {
        console.error(err);
      }
    });*/
  }

  ngOnInit(): void {
    this.announcements$ = this.announcementDbService.getAnnouncements();
  }

  onClick(titleDb: string, dateDb: Date, idDb: number) {
    this.router.navigate(['api/announcement', titleDb, dateDb, idDb]);
  } 
}
