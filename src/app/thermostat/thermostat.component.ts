import { Component, OnInit, Input } from '@angular/core';
import { Thermostat } from '../home';

@Component({
  selector: 'app-thermostat',
  templateUrl: './thermostat.component.html',
  styleUrls: ['./thermostat.component.css']
})
export class ThermostatComponent implements OnInit {

  @Input()
  id: string;

  @Input()
  thermostats: Thermostat[];

  thermostat: any;

  constructor() { }

  ngOnInit(): void {
    this.thermostat = this.thermostats.find(x => x.deviceId == this.id);
  }

}
