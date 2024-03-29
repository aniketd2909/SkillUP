import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient, private router: Router, private toastr: ToastrService) { }
  register(path, data): Observable<any> {
    return this.httpClient.post(`${environment.baseUrl}/${path}`, data, { responseType: 'text' });
  }
  login(data): Observable<any> {
    return this.httpClient.post(`${environment.baseUrl}/login`, data
    );
  }
  getToken() {
    return localStorage.getItem('jwtToken');
  }
  saveItem(key: string, val: string) {
    localStorage.setItem(key, val);
  }
  logout() {
    localStorage.removeItem('jwtToken');
    localStorage.removeItem('roleId');
    localStorage.removeItem('email');
    this.toastr.warning('You Have Successfully Logged Out', 'Logout')

    this.router.navigate(['authentication/login']);
  }
  isLoggedIn() {
    return !!localStorage.getItem('jwtToken');
  }

  getUserRole() {

    // if (localStorage.getItem('roleId') === '1')
    //   return true;
    // return false;
    if (localStorage.getItem('roleId') === '1')
      return 'campusMind';
    if (localStorage.getItem('roleId') === '2')
      return 'mindtreeMind'
    if (localStorage.getItem('roleId') === '3')
      return 'admin';
      return 'none'
  }

  getEmail()
  {
    return localStorage.getItem('email')
  }

}
