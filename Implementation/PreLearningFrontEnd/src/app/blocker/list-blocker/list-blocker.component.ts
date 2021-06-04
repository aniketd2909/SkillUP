import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-list-blocker',
  templateUrl: './list-blocker.component.html',
  styleUrls: ['./list-blocker.component.css']
})
export class ListBlockerComponent implements OnInit {


  constructor(private apiService: ApiService) { }
  blockerList: any=[];
  

  ngOnInit(): void {
    this.refreshBlockerList();
  }

  refreshBlockerList() {
    this.apiService.get('blocker').subscribe((result) => {
      this.blockerList = result;
      console.log(result);
    });
  }

  
}
