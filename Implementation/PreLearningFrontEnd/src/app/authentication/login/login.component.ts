import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(16),
    ]),
  });
  constructor(private authService: AuthService,private route: Router) {}

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginForm.value).subscribe(
      (response) => {
       //console.log(response.token)
        // let val:any = response
        // console.log(val.token)
       this.authService.saveItem('jwtToken',response.token);
       this.authService.saveItem('roleId',response.roleId);
       this.authService.saveItem('email',response.email);
        alert('login successfull');
        this.loginForm.reset()
        this.route.navigate(['home']);
      },
      (error) => {console.log(error.error),alert(error.error)}
    );
  }
}
