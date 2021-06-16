import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-list-topic',
  templateUrl: './list-topic.component.html',
  styleUrls: ['./list-topic.component.css'],
})
export class ListTopicComponent implements OnInit {
  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.refreshTopicList();
  }
  typesOfTopics: any = [];
  //typesOfTopicss: string[] = ['vv','tt links', 'webtgsdfgdfsite links'];

  refreshTopicList() {
    this.apiService.get('topic').subscribe((result) => {
      this.typesOfTopics = result;
      console.log(result);
    }, (error) => {console.log(error.error),alert(error.error)});
  }
}
