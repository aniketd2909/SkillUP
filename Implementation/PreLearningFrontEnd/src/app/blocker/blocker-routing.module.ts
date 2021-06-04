import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSolutionComponent } from './add-solution/add-solution.component';
import { BlockerComponent } from './blocker.component';
import { ListBlockerComponent } from './list-blocker/list-blocker.component';

const routes: Routes = [{ path: '', component: BlockerComponent },
{ path: 'list', component: ListBlockerComponent },
{ path: 'add/:id', component: AddSolutionComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BlockerRoutingModule {}
