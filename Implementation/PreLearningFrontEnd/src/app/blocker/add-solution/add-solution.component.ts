import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-add-solution',
  templateUrl: './add-solution.component.html',
  styleUrls: ['./add-solution.component.css']
})
export class AddSolutionComponent implements OnInit {

  listBlocker: string= 'Array';
  constructor(private apiService: ApiService,private router:ActivatedRoute,private route: Router) { }
  addSolution= new FormGroup({
    solution: new FormControl(''),
    blockerId: new FormControl(this.router.snapshot.params.id) 
  });


  Blocker: any;
  ngOnInit(): void {
    console.log(this.router.snapshot.params.id);
    this.apiService.getById('blocker',this.router.snapshot.params.id).subscribe((result)=>{
      console.log(result);
      this.Blocker=result;
  
    });

  }

  collectSolution(){
    console.log(this.addSolution.value);
    this.apiService.post('BlockerSolution',this.addSolution.value).
    subscribe((result)=>{
      console.log(result);
      this.route.navigate(['blocker/list']);  
  
    });
    

  }


  

}
