import { Component, OnInit, Input } from '@angular/core';
import { AirConditioner } from '../home';

@Component({
  selector: 'app-ac',
  templateUrl: './ac.component.html',
  styleUrls: ['./ac.component.css']
})
export class AcComponent implements OnInit {

  @Input()
  id: string;

  @Input()
  acs: AirConditioner[];

  ac: AirConditioner;

  constructor() { }

  ngOnInit(): void {
    this.ac = this.acs.find(x => x.DeviceId == this.id);
  }

}
