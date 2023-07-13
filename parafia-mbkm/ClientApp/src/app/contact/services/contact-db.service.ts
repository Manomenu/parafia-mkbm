import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { contact } from '../models/contact';

@Injectable({
  providedIn: 'root',
})
export class ContactDbService {
  addContact(contactData: contact) {
    //todo zrobic dodawanie do bazy danych
    throw new Error('Method not implemented.');
  }
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  getContacts() {
    return this.http.get<contact[]>(this.baseUrl + 'api/contact');
  }
}
