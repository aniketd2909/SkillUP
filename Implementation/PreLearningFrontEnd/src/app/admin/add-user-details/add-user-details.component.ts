import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-add-user-details',
  templateUrl: './add-user-details.component.html',
  styleUrls: ['./add-user-details.component.css']
})
export class AddUserDetailsComponent implements OnInit {


  // @ViewChild('fileInput') fileInput;
  // message: string;
  // Form!: FormGroup;
  // List: any;

  //flag :boolean =false

  constructor(private fb: FormBuilder, private apiService: ApiService, private route: Router,
    private toastr: ToastrService) { }
  ngOnInit(): void {

  }



  onFileUpload(event) {
    //  this.flag = true;
    const file = event.files[0];
    //this.progressBar = true;
    console.log(file)
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    this.apiService.UploadExcel('SelectedUser', formData).subscribe(response => {
      if (response.message === 'Users Added')
        this.toastr.success(response.message, 'Adding Users')
      else
        this.toastr.error(response.message, 'Adding Users')

    }, error => console.log(error))
  }

}
