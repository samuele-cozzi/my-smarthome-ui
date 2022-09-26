import { Component, OnInit } from '@angular/core';
import { HomeApiService } from '../home-api.service';
import { Home } from '../home';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  home: Home | undefined;
  disabled: boolean = true;

  constructor(private homeService: HomeApiService) { }

  ngOnInit(): void {
    this.homeService.get()
      .subscribe(res => this.home = res);
  }

  enableSettings(){
    this.disabled = false;
  }

  save(){
    this.homeService.save(this.home)
      .subscribe(res => console.log(res));
    this.disabled = true;
  }
}
