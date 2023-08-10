import { Component } from '@angular/core';
import { OneSignal } from 'onesignal-ngx';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ui-ac-controller';

  constructor(private oneSignal: OneSignal) {
    this.oneSignal.init({
      appId: "17d959dc-69a8-48d7-be88-8cae68dd2ea2",
      serviceWorkerParam: {
        scope: '/assets/push/'
      },
      serviceWorkerPath: '/assets/push/'
    });
  }
}