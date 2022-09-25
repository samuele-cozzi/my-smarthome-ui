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
  mode: string;

  constructor(private homeService: HomeApiService) { }

  ngOnInit(): void {
    this.homeService.get().subscribe(res => this.home = res);
  }

}
