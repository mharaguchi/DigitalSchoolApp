import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  constructor(private http: HttpClient) {}
  private url = 'https://localhost:50416/WeatherForecast/GetTestName';

  getTestName(): Observable<string> {
    return this.http.get<string>(this.url);
  }
}
