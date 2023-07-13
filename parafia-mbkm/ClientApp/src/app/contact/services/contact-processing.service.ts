import { Injectable } from '@angular/core';
import { contact } from '../models/contact';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class ContactProcessingService {
  buildContactData(contactForm: FormGroup): contact {
    return {
      contactTitle: contactForm.value.contactTitle,
      contactLines: [],
    };
    //todo zrobic tutaj parsowanie contactLines
  }
}
