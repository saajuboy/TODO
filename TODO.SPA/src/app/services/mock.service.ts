import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MockService {

  constructor(private http: HttpClient) { }

  getWeatherForcast(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7126/WeatherForecast');
  }
}

