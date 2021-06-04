import { ApiService } from './../../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-experience-feed',
  templateUrl: './add-experience-feed.component.html',
  styleUrls: ['./add-experience-feed.component.css']
})
export class AddExperienceFeedComponent implements OnInit {

  feedForm!: FormGroup;
  feedList: any;
  constructor(private fb: FormBuilder,private apiService:ApiService) { }

  ngOnInit(): void {
    this.feedForm = this.fb.group({
     Comment: ['']
    });
    this.OnSubmit
  }

  OnSubmit() {
    this.apiService.post('ExperienceFeed',this.feedForm.value).subscribe();
  }

  resetForm(){
    this.feedForm.reset();
  }
}

