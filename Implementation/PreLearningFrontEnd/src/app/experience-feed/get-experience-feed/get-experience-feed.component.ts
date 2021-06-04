import { Component, OnInit } from '@angular/core';
interface feed {
  id: Number;
  comment: String;
  postedAt: number;
 
}
@Component({
  selector: 'app-get-experience-feed',
  templateUrl: './get-experience-feed.component.html',
  styleUrls: ['./get-experience-feed.component.css']
})
export class GetExperienceFeedComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  feeds: feed[] = [
    {
      id: 1,
      comment: "overall good exper",
      postedAt:Date.now()
     
    },
    {
      id: 2,
      comment: "overall worst exper",
      postedAt:Date.now()
    },
    {
      id: 3,
      comment: "comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 comment3 ",
      postedAt:Date.now()
    },
    {
      id: 4,
      comment: "overall worst exper",
      postedAt:Date.now()
    },
    {
      id: 5,
      comment: "overall worst exper",
      postedAt:Date.now()
    },]

}
