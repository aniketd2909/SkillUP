import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayMcqComponent } from './display-mcq/display-mcq.component';
import { DisplayProblemStatementsComponent } from './display-problem-statements/display-problem-statements.component';
import { PracticeComponent } from './practice.component';

const routes: Routes = [{path:'mcq' ,component:DisplayMcqComponent},
{path:'problemStatement' ,component:DisplayProblemStatementsComponent},
  { path: '', component: PracticeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PracticeRoutingModule { }
