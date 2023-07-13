import { Component, OnInit } from '@angular/core';
import { contact } from './models/contact';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ContactDbService } from './services/contact-db.service';
import { ContactProcessingService } from './services/contact-processing.service';

@Component({
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent implements OnInit {
  public contacts: contact[] = [];
  public contactForm!: FormGroup;

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
    this.contactDbService.getContacts().subscribe({
      next: (result) => {
        this.contacts = result;
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  ///<forms functions>
  async saveContactForm(): Promise<void> {
    await this.contactDbService.addContact(
      this.contactProcessingService.buildContactData(this.contactForm)
    );
  }

  get contactLinesForms(): FormArray {
    return this.contactForm.get('contactLines') as FormArray;
  }

  addContactLineFormGroup(): void {
    this.contactLinesForms.push(
      this.fb.group({
        icon: ['will be dropdown field'],
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
