import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MockService } from './services/mock.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TODO.SPA';

  testArray:any[] = [];

  constructor (private _mockService:MockService,private router: Router){

    // _mockService.getWeatherForcast().subscribe(x=>{
    //   this.testArray = x;
    // });
  }

  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }

  isArchive(){
    let route = this.router.url;

    if(route.includes('archived')){
      return true;
    }
    return false;
  }

}
