import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

interface feed {
  id: Number;
  comment: String;
  postedAt: any|Date;
  email: string;
}
@Component({
  selector: 'app-get-experience-feed',
  templateUrl: './get-experience-feed.component.html',
  styleUrls: ['./get-experience-feed.component.css']
})
export class GetExperienceFeedComponent implements OnInit {
flag:number=1;

  constructor(private apiService:ApiService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  feeds:feed[];

    refreshList() {
      this.apiService.get('ExperienceFeed').subscribe((result) => {
        this.feeds = result;
      }, (error) => {console.log(error.error),alert(error.error)});
    }

}
