import { Component, OnInit, Input } from '@angular/core';
import { AirConditioner, Home } from '../home';
import { HomeApiService } from '../home-api.service';

@Component({
  selector: 'app-ac',
  templateUrl: './ac.component.html',
  styleUrls: ['./ac.component.css']
})
export class AcComponent implements OnInit {

  @Input()
  id: string;

  @Input()
  home: Home;

  ac: AirConditioner;

  constructor(private homeService: HomeApiService) { }

  ngOnInit(): void {
    this.ac = this.home.AirConditioners.find(x => x.DeviceId == this.id);
  }

  powerOn(){
    this.homeService.ACpower(true, this.ac.DeviceId, this.home)
      .subscribe(res => console.log(res));
    this.ac.Power = true;
  }

  powerOff(){
    this.homeService.ACpower(false, this.ac.DeviceId, this.home)
      .subscribe(res => console.log(res));
    this.ac.Power = false;
  }
}
