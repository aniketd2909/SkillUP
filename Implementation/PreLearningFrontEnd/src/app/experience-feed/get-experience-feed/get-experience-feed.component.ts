import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

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

  constructor(private apiService:ApiService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  feeds:feed[];

    refreshList() {
      this.apiService.get('ExperienceFeed').subscribe((result) => {
        this.feeds = result;

        console.log(result);
      });
    }

}
