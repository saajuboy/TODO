import { Component } from '@angular/core';
import { MockService } from './services/mock.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TODO.SPA';

  testArray:any[] = [];
  constructor (private _mockService:MockService){

    _mockService.getWeatherForcast().subscribe(x=>{
      this.testArray = x;
    });
  }


}
