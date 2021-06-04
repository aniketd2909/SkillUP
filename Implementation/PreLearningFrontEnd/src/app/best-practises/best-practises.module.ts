import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BestPractisesRoutingModule } from './best-practises-routing.module';
import { BestPractisesComponent } from './best-practises.component';
import { ListPractisesComponent } from './list-practises/list-practises.component';
import { AddPractisesComponent } from './add-practises/add-practises.component';


@NgModule({
  declarations: [
    BestPractisesComponent,
    ListPractisesComponent,
    AddPractisesComponent
  ],
  imports: [
    CommonModule,
    BestPractisesRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class BestPractisesModule { }
