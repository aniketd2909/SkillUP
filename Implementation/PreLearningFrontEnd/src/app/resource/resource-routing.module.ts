import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListTopicComponent } from './list-topic/list-topic.component';
import { ResourceComponent } from './resource.component';

const routes: Routes = [{ path: '', component: ResourceComponent },
{ path: 'topics', component: ListTopicComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResourceRoutingModule { }
