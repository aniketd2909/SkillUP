
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-list-blocker',
  templateUrl: './list-blocker.component.html',
  styleUrls: ['./list-blocker.component.css']
})
export class ListBlockerComponent implements OnInit {

  private _listBlocker: string='';

  get listBlocker(): string{

    return this._listBlocker;
  }

  set listBlocker(value :string){
    this._listBlocker=value;
    this.filteredBlockers=this.performFilter(value);
  //  console.log(value);
  } 

  constructor(private apiService: ApiService,private route:Router) { }
  blockerList: any=[]; 
  filteredBlockers: any=[];

  ngOnInit(): void {

    this.refreshBlockerList();
   // this.route.navigate(['blocker']); 

  }

  refreshBlockerList() {
    this.apiService.get('blocker').subscribe((result) => {
      this.blockerList = result;
      this.filteredBlockers=result;
      console.log(result);
    });
  }

  // performFilter(filterBy: string): any{

  //    filterBy=filterBy.toLocaleLowerCase(); 
  //    return this.blockerList.filter((blocker: any)=>blocker.name.toLocaleLowerCase.include(filterBy));


  //     // let i=0;
  //     // for (let index = 0; index < this.blockerList.length; index++) {
  //     //   if(this.blockerList[index].name==filterBy){
  //     //     this.filter[i]=this.blockerList[index];
  //     //     i++;
  //     //   }
        
  //     // }
  //     // return this.filter;


  //  }

   performFilter(filterBy: string): any {
    if (filterBy) {
        filterBy = filterBy.toLocaleLowerCase();
        return this.blockerList.filter((blocker: any) =>
            blocker.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
    } else {
        return this.blockerList;
    }
}
}
