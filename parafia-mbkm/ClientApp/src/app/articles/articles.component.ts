import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})

export class ArticlesComponent {
  public articles: Article[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Article[]>(baseUrl + 'api/article').subscribe({
      next: (result) => {
        this.articles = result;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}

interface Article {
  header: string;
  content: number;
}
