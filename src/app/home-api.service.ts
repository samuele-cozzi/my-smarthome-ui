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
}
