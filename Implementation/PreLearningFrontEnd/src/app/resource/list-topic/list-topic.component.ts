import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-list-topic',
  templateUrl: './list-topic.component.html',
  styleUrls: ['./list-topic.component.css']
})
export class ListTopicComponent implements OnInit {

  constructor(private service:ApiService) { }

  ngOnInit(): void {
    this.refreshTopicList();
  }
  typesOfTopics:any=[];
  //typesOfTopicss: string[] = ['vv','tt links', 'webtgsdfgdfsite links'];
  ResourcesHeadings: string[] = ['Discription','youtube links', 'website links'];

  refreshTopicList() {
    this.service.get('topic').subscribe((result)=>{
      this.typesOfTopics = result;
    })
  }
}
