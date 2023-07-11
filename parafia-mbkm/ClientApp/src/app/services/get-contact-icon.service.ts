import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GetContactIconService {

  getContactIconSource(icon: string): string {
    return "assets/contact-images/" + icon + ".png";
  }
}
