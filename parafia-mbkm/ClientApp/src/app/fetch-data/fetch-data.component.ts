import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    var x = baseUrl + 'weatherforecast'
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe({
      next: (result) => {
        this.forecasts = result;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
