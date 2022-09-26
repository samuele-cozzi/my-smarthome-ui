import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Home } from './home';

@Injectable({
  providedIn: 'root'
})
export class HomeApiService {

  constructor(private http: HttpClient) { }

  get(): Observable<Home> {
    var response = this.http.get<Home>('/api/GetHome');
    return response;
  }

  save(home: Home) {
    return this.http.post('/api/PostConfiguration', home.Configuration);
  }

  ACpower(power: boolean, acId:string, home: Home) {
    var ac = {
      "DeviceId": acId,
      "Power": power,
      "Mode": home.Configuration.AirMode,
      "Fan": home.Configuration.AirFan,
      "Temp": home.Configuration.AirTemperature
    };

    return this.http.post('/api/PostAirConditioner', ac);
  }
}
