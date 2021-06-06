import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayMcqComponent } from './display-mcq/display-mcq.component';
import { PracticeComponent } from './practice.component';

const routes: Routes = [{path:'mcq' ,component:DisplayMcqComponent},
  { path: '', component: PracticeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PracticeRoutingModule { }
