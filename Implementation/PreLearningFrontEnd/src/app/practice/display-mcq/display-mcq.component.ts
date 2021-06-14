import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
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
    optionId: new FormControl('', [Validators.required])
  })
  
  constructor(private apiService: ApiService, private toastr: ToastrService) { }
currentIndex=0;
mcqLength;
validButton: boolean=false;

questionNumber: number=1;
 
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
    console.log("Question ID =" + qtionId);
    console.log("Form Details =" + this.mcqForm.value.optionId);

    this.apiService.postAnswer(`mcq/${qtionId}`, this.mcqForm.value).subscribe((response) => {
      // console.log(response);
      if (response === 'Correct') {
       // alert('Correct Answer');
       this.toastr.success('Correct Answer','Result',{positionClass:'toast-bottom-right'})
      }
      else {
        //alert('Wrong Answer');
        this.toastr.error('Wrong Answer','Result',{positionClass:'toast-bottom-right'})
      }
    });
  }

  getMcqs() {
    this.apiService.get('mcq').subscribe(response => {
      this.mcqs = response
      console.log(response)
      this.getMcq(this.mcqs[this.currentIndex].id)
      this.mcqLength = this.mcqs.length
    }, (error) => { console.log(error.error); alert(error.error) })
  }

  nextQuestion() {
    this.getMcq(this.mcqs[++this.currentIndex].id)
    this.questionNumber++;
    this.validButton=false;
    // console.log(question)
    // let index = this.mcqs.indexOf(question)
    // console.log(index)
    // this.getMcq(this.mcqs[index + 1].id)
    // console.log(idval)
    // this.id =2;
    // console.log(this.id)
    // this.getMcq()
  }

  previousQuestion() {
    this.getMcq(this.mcqs[--this.currentIndex].id)
    this.questionNumber--;
    this.validButton=false;
  }

  isSelected(){
    this.validButton=true;
  }

}
