import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(private authService: AuthService, private toastr: ToastrService) { }

  campusMind: boolean = false;
  mindTreeMind: boolean = false;

  registerForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    email: new FormControl('', [Validators.email]),
    contactNo: new FormControl('', [
      Validators.required,
      Validators.maxLength(12),
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.maxLength(16),
    ]),
    gender: new FormControl('', [Validators.required, Validators.maxLength(8)]),
    roleId: new FormControl('', [Validators.required]),
  });

  ngOnInit(): void { }
  campusMindRole() {
    this.campusMind = true;
    this.mindTreeMind = false;
    this.registerForm.addControl(
      'engineeringBranch',
      new FormControl('', [Validators.required, Validators.maxLength(50)])
    );
    this.registerForm.removeControl('location');
    this.registerForm.removeControl('track');
  }
  mindtreeMindRole() {
    this.campusMind = false;
    this.mindTreeMind = true;
    this.registerForm.addControl(
      'location',
      new FormControl('', [Validators.required, Validators.maxLength(50)])
    );
    this.registerForm.addControl(
      'track',
      new FormControl('', [Validators.required, Validators.maxLength(50)])
    );
    this.registerForm.removeControl('engineeringBranch');
  }

  collectData() {
    this.registerForm.value.roleId = +this.registerForm.value.roleId;
    console.log(this.registerForm.value);
    let path =
      this.registerForm.value.roleId == 1 ? 'CampusMindRegister' : 'MindTreeMindRegister';
    this.authService.register(path, this.registerForm.value).subscribe(
      (response) => {
        console.log(response);
        //alert(response)
        if (response === 'Registration Successful') {
          this.toastr.success(response, 'Registration')
        }
        else {
          this.toastr.error(response, 'Registration')
        }

        this.registerForm.reset();
      },
      (error) => { console.log(error.error) }

    );
  }
}
