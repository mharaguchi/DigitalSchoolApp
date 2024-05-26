import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WeatherService } from './weather.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  name$!: Observable<string>;

  constructor(private weatherService: WeatherService) {}

  ngOnInit(): void {
    this.name$ = this.weatherService.getTestName();
  }
}
