import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-add-user-details',
  templateUrl: './add-user-details.component.html',
  styleUrls: ['./add-user-details.component.css']
})
export class AddUserDetailsComponent implements OnInit {
  @ViewChild('fileInput') fileInput; 
  message: string; 
  Form!: FormGroup;
  List: any;
  constructor(private fb: FormBuilder,private apiService:ApiService,private route: Router,private http:HttpClient) { }
  url = 'https://localhost:44363/api/SelectedUser';
  ngOnInit(): void {
    this.onFileUpload
  }
  // uploadFile() {  
  //   let formData = new FormData();  
  //   formData.append('upload', this.fileInput.nativeElement.files[0])  
  
  //   this.UploadExcel(formData).subscribe(result => {  
  //     this.message = result.toString();  
      
  //   });   
  
  // }  
  onFileUpload(event) {
    
    const file = event.files[0];
    //this.progressBar = true;
    console.log(event)
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    this.UploadExcel(formData).subscribe(x => console.log(x),error=>console.log(error));
  }
  UploadExcel(formData: FormData) {  
    let headers = new HttpHeaders();  
  
    headers.append('Content-Type', 'multipart/form-data');  
    headers.append('Accept', 'application/json');  
  
    const httpOptions = { headers: headers};  
  
    return this.http.post(this.url , formData, httpOptions)  
  }  
}
