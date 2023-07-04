import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent {
  public contacts: contact[] = [];

  httpGetRequest() {
    this.http.get<contact[]>(this.baseUrl + 'api/contact').subscribe({
      next: (result) => {
        this.contacts = result;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.httpGetRequest();
  }

}

interface contact {
  contactTitle: string;
  contactLines: { category: string, value: string }[];
}

