import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PracticeRoutingModule } from './practice-routing.module';
import { PracticeComponent } from './practice.component';
import { DisplayMcqComponent } from './display-mcq/display-mcq.component';
import {  ReactiveFormsModule } from '@angular/forms';
import { DisplayProblemStatementsComponent } from './display-problem-statements/display-problem-statements.component';
import { LineBreakPipe } from './Pipes/line-break.pipe';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTreeModule} from '@angular/material/tree';
import { MatListModule } from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';

@NgModule({
  declarations: [
    PracticeComponent,
    DisplayMcqComponent,
    DisplayProblemStatementsComponent,
    LineBreakPipe
  ],
  imports: [
    CommonModule,
    PracticeRoutingModule,
    ReactiveFormsModule,
    MatTabsModule,
    MatTreeModule,
    MatListModule,
    MatExpansionModule
  ]
})
export class PracticeModule { }
