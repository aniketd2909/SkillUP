import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
      Validators.minLength(8),
      Validators.maxLength(16),
    ]),
  });
  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  login() {
    this.authService.login(this.loginForm.value).subscribe(
      (response) => {
       //console.log(response.token)
        // let val:any = response
        // console.log(val.token)
       this.authService.saveItem('jwtToken',response.token);
       this.authService.saveItem('roleId',response.roleId);
        alert('login successfull');
        this.loginForm.reset()
      },
      (error) => console.log(error)
    );
  }
}
