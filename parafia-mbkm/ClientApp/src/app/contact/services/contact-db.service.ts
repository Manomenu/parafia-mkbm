import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { contact } from '../models/contact';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactDbService {
  private endpoint!: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.endpoint = this.baseUrl + 'api/contact';
  }

  addContact(contactData: contact): Observable<Object> {
    return this.http.post(this.endpoint, contactData, {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
    });
  }

  public getContacts(): Observable<contact[]> {
    return this.http.get<contact[]>(this.endpoint);
  }
}
