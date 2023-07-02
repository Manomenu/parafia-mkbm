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

  httpGetRequest() {
    this.http.get<Article[]>(this.baseUrl + 'api/article').subscribe({
      next: (result) => {
        this.articles = result;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private fb: FormBuilder) {
    this.httpGetRequest();
  }
  onSubmit(): void {
    this.http.post(
      this.baseUrl + 'api/article',
      new Article(
        (this.addForm.value.header || '').toString(),
        (this.addForm.value.content || '').toString())
    ).subscribe({
      next: (result) => {
        console.log(result)
      },
      error: (err) => {
        console.log(err);
      }
    });
    this.httpGetRequest();
  }
}

export class Article {
  public header: string;
  public content: string;
  constructor(header: string, content: string) {
    this.header = header;
    this.content = content;
  }
}
