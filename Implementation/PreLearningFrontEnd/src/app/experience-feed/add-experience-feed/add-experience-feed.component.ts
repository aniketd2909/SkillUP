import { ApiService } from './../../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, FormControlName } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-add-experience-feed',
  templateUrl: './add-experience-feed.component.html',
  styleUrls: ['./add-experience-feed.component.css']
})
export class AddExperienceFeedComponent implements OnInit {

  feedForm!: FormGroup;
  feedList: any;
  constructor(private fb: FormBuilder,private apiService:ApiService,private route: Router) { }

  ngOnInit(): void {
    this.feedForm = this.fb.group({
     Comment: [''],
      postedAt: new Date(),
     email:localStorage.getItem('email')
    });
    this.OnSubmit
  }

  OnSubmit() {
    this.apiService.post('ExperienceFeed',this.feedForm.value).subscribe((response)=>{
      console.log(response)
    }, (error) => {console.log(error.error),alert(error.error)});
  }

  resetForm(){
    this.feedForm.reset();
    this.route.navigate(['experience-feed/get']);
  }
}

