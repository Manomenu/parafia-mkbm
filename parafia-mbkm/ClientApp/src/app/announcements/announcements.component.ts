import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Announcement } from './models/announcement';

@Component({
  selector: 'app-announcements',
  templateUrl: './announcements.component.html',
  styleUrls: ['./announcements.component.css']
})
export class AnnouncementsComponent {
  public announcements: Announcement[] = [];
  public announcementForm!: FormGroup;
  public idRef: number = -1;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder
  ) {
    
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => console.log("params : ", params));
    http.get<Announcement[]>(baseUrl + 'api/announcement').subscribe({
      next: (result) => {
        this.announcements = result;
        console.log(result);
      }, error: (err) => {
        console.error(err);
      }
    });
  }

  onClick(titleDb: string, dateDb: Date, idDb: number) {
    this.router.navigate(['api/announcement', titleDb, dateDb, idDb]);
  } 
}
