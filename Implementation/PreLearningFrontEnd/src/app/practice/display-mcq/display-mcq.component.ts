import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { a } from 'src/app/Models/IQuestion';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-display-mcq',
  templateUrl: './display-mcq.component.html',
  styleUrls: ['./display-mcq.component.css']
})

export class DisplayMcqComponent implements OnInit {
  mcq: any;
  mcqs: any = []
  mcqForm = new FormGroup({
    optionId: new FormControl('',[Validators.required])
  })
currentIndex=0
mcqLength
  constructor(private apiService: ApiService) { }

  ngOnInit(): void {

    this.getMcqs();

  }
  getMcq(id) {
    this.apiService.get(`mcq/${id}`).subscribe((response) => {
      this.mcq = response
        console.log(response)
    });

  }
  onSubmit(qtionId) {
    console.log("Question ID ="+qtionId);
    console.log("Form Details ="+this.mcqForm.value.optionId);
    
    this.apiService.postAnswer(`mcq/${qtionId}`, this.mcqForm.value).subscribe((response) => {
     // console.log(response);
      if (response === 'Correct') alert('Correct Answer');
      else alert('Wrong Answer');
    });
  }

  getMcqs() {
    this.apiService.get('mcq').subscribe(response => {
      this.mcqs = response
      console.log(response)
      this.getMcq(this.mcqs[this.currentIndex].id)
      this.mcqLength=this.mcqs.length
    }
      , error => console.log(error))
  }

  nextQuestion() {
    this.getMcq(this.mcqs[++this.currentIndex].id)

    // console.log(question)
    // let index = this.mcqs.indexOf(question)
    // console.log(index)
    // this.getMcq(this.mcqs[index + 1].id)
    // console.log(idval)
    // this.id =2;
    // console.log(this.id)
    // this.getMcq()
  }

  previousQuestion()
  {
    this.getMcq(this.mcqs[--this.currentIndex].id)
  }


}
