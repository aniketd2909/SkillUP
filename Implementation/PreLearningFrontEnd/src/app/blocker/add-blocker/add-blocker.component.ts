import { getLocaleDateTimeFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

import { ApiService } from 'src/services/api.service';



@Component({
  selector: 'app-add-blocker',
  templateUrl: './add-blocker.component.html',
  styleUrls: ['./add-blocker.component.css']
})
export class AddBlockerComponent implements OnInit {




  constructor(private apiService: ApiService, private _snackBar: MatSnackBar, private route: Router) { }
  addBlocker = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    createdAt: new FormControl(new Date)
  });
  ngOnInit(): void {

  }



  openSnackBar() {
    this._snackBar.open("Your doubt is Added");
  }

  collectBlocker() {
    this.apiService.post('blocker', this.addBlocker.value).subscribe((result) => {
      console.warn(result);
    }, (error) => {console.log(error.error),alert(error.error)}
    );
    this.addBlocker.reset({});
    //this.list.refreshBlockerList();
    //location.reload();
    //  this.route.navigate(['blocker/list']);
    window.location.reload();
  }


}
