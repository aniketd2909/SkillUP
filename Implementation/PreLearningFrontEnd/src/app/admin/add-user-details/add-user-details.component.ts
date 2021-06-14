import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-add-user-details',
  templateUrl: './add-user-details.component.html',
  styleUrls: ['./add-user-details.component.css']
})
export class AddUserDetailsComponent implements OnInit {

  Form!: FormGroup;
  List: any;
  constructor(private fb: FormBuilder,private apiService:ApiService,private route: Router) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
     file: ['']   
    });
    this.OnSubmit
  }

  OnSubmit() {
    this.apiService.post('SelectedUser',this.Form.value).subscribe((response)=>{
      console.log(response)
    }, (error) => {console.log(error.error),alert(error.error)});
  }

  resetForm(){
    this.Form.reset();
    alert("Added successfully!")
   
  }
}
