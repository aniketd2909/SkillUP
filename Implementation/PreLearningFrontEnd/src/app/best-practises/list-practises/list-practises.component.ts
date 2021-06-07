import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';
interface bestPractise{
  id:number;
  bestPractise:string;
}

@Component({
  selector: 'app-list-practises',
  templateUrl: './list-practises.component.html',
  styleUrls: ['./list-practises.component.css']
})
export class ListPractisesComponent implements OnInit {

  constructor(private apiService:ApiService) { }

  bestPractises:bestPractise[];

  ngOnInit(): void {
    this.refreshTopicList();
  }

  refreshTopicList() {
    this.apiService.get('BestPractice').subscribe((result) => {
      this.bestPractises = result;
      console.log(result);
    });
  }
}
