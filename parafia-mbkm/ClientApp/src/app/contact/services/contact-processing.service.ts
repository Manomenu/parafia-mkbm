import { Injectable } from '@angular/core';
import { contact } from '../models/contact';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ContactProcessingService {
  buildContactData(contactForm: FormGroup): contact {
    return contactForm.value;
    // akurat w tym formularzu .value zwraca dokładnie taki format jak trzeba to nic tu sie nie dzieje
  }
}
