import { Component, Injector } from '@angular/core';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'PreLearningFrontEnd';
  authService: AuthService = this.injector.get(AuthService);
  constructor(private injector: Injector) {}
}
