import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { announcement } from '../models/announcement';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementDbService {
  private endpoint!: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.endpoint = this.baseUrl + 'api/announcement';
  }

  public getAnnouncements(): Observable<announcement[]> {
    return this.http.get<announcement[]>(this.endpoint);
  }
}

/*this.route.params.subscribe(params => console.log("params : ", params));
http.get<Announcement[]>(baseUrl + 'api/announcement').subscribe({
  next: (result) => {
    this.announcements = result;
    console.log(result);
  }, error: (err) => {
    console.error(err);
  }
});*/
