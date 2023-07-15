import { Component, OnInit } from '@angular/core';
import { contact } from './models/contact';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ContactDbService } from './services/contact-db.service';
import { ContactProcessingService } from './services/contact-processing.service';
import { contactIconTypes } from './data/contact-icon-types';
import { Observable } from 'rxjs';

@Component({
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent implements OnInit {
  public contacts$!: Observable<contact[]>;
  public contactForm!: FormGroup;
  public contactIconTypes!: { value: string }[];

  constructor(
    private contactProcessingService: ContactProcessingService,
    private fb: FormBuilder,
    private contactDbService: ContactDbService
  ) {
    this.contactForm = fb.group({
      contactTitle: [''],
      contactLines: fb.array([]),
    });
  }

  ngOnInit(): void {
    this.contactIconTypes = contactIconTypes;
    this.contacts$ = this.contactDbService.getContacts();
  }

  ///<forms functions>
  async saveContactForm(): Promise<void> {
    await this.contactDbService
      .addContact(
        this.contactProcessingService.buildContactData(this.contactForm)
      )
      .subscribe({
        next: () => {
          this.contacts$ = this.contactDbService.getContacts();
        },
        error: (err) => {
          console.log(err);
        },
      });
  }

  get contactLinesForms(): FormArray {
    return this.contactForm.get('contactLines') as FormArray;
  }

  addContactLineFormGroup(): void {
    this.contactLinesForms.push(
      this.fb.group({
        icon: ['click here to choose an icon'],
        category: [''],
        value: [''],
      })
    );
  }

  removeContactLineFormGroup(index: number): void {
    this.contactLinesForms.removeAt(index);
  }
  ///</forms functions>

  getContactIconSource(icon: string) {
    return 'assets/contact-images/' + icon + '.png';
  }
}
