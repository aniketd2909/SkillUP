import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-display-problem-statements',
  templateUrl: './display-problem-statements.component.html',
  styleUrls: ['./display-problem-statements.component.css']
})
export class DisplayProblemStatementsComponent implements OnInit {

  constructor(private apiService: ApiService) { }
  problemsList :any =[]
  ngOnInit(): void {
this.loadProblems()
  }

  loadProblems()
  {
    this.apiService.get('ProblemStatement').subscribe((response)=>{
     // console.log(response)
    //  response= response.value
      this.problemsList = response
    //   this.problemsList.forEach(element => {element.question =element.question.replaceAll("\r\n","<br>")
    
    // });
      console.log(this.problemsList)

    })
  }


}
