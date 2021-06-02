import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient, private router: Router) {}
  register(path, data): Observable<any> {
    return this.httpClient.post(`${environment.baseUrl}/${path}`, data);
  }
  login(data) {
    return this.httpClient.post(`${environment.baseUrl}/login`, data, {
      responseType: 'text',
    });
  }
  getToken() {
    return localStorage.getItem('jwtToken');
  }
  saveToken(token) {
    localStorage.setItem('jwtToken', token);
  }
  logout() {
    localStorage.removeItem('jwtToken');
    this.router.navigate(['authentication/login']);
  }
  isLoggedIn() {
    return !!localStorage.getItem('jwtToken');
  }
}
