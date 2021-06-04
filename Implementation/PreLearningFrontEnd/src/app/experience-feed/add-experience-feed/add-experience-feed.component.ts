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
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.feedForm = this.fb.group({
     Comment: ['']
      
    });
  }
  OnSubmit() {
    
  }
  resetForm(){
    this.feedForm.reset();
  }
}

