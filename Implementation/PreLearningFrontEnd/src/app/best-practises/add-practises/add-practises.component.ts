import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-add-practises',
  templateUrl: './add-practises.component.html',
  styleUrls: ['./add-practises.component.css']
})
export class AddPractisesComponent implements OnInit {

  feedForm!: FormGroup;
  feedList: any;
  constructor(private fb: FormBuilder,private apiService:ApiService) { }

  ngOnInit(): void {
    this.feedForm = this.fb.group({
      Comment: ['']
     });
    this.OnSubmit
  }

  OnSubmit(data:any) {
    this.apiService.post('BestPractice',data).subscribe();
  }
  
  resetForm(){
    this.feedForm.reset();
  }

}
