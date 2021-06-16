import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPractisesComponent } from './add-practises/add-practises.component';
import { BestPractisesComponent } from './best-practises.component';
import { ListPractisesComponent } from './list-practises/list-practises.component';

const routes: Routes = [{ path: '', component: BestPractisesComponent },
{path:'list',component:ListPractisesComponent},
{path:'add',component:AddPractisesComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BestPractisesRoutingModule { }
