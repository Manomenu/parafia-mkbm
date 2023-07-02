import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})


export class ArticlesComponent {
  public articles: Article[] = [];
  addForm = this.fb.group({
    header: '',
    content: ''
  })
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fb: FormBuilder) {
    http.get<Article[]>(baseUrl + 'api/article').subscribe({
      next: (result) => {
        this.articles = result;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
  onSubmit(): void {
    console.log('submitted form', this.addForm.value);
     
  }
}


interface Article {
  header: string;
  content: number;
}
