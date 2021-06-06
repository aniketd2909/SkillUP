import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PracticeRoutingModule } from './practice-routing.module';
import { PracticeComponent } from './practice.component';
import { DisplayMcqComponent } from './display-mcq/display-mcq.component';
import {  ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PracticeComponent,
    DisplayMcqComponent
  ],
  imports: [
    CommonModule,
    PracticeRoutingModule,
    ReactiveFormsModule
  ]
})
export class PracticeModule { }
