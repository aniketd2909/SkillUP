import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-get-experience-feed',
  templateUrl: './get-experience-feed.component.html',
  styleUrls: ['./get-experience-feed.component.css']
})
export class GetExperienceFeedComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  feeds:any=['feed1','feed2','feed3'];

}
