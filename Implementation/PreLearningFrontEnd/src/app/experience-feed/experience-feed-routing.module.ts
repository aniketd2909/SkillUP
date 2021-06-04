import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UpdateExperienceFeedComponent } from './update-experience-feed/update-experience-feed.component';
import { GetExperienceFeedComponent } from './get-experience-feed/get-experience-feed.component';
import { AddExperienceFeedComponent } from './add-experience-feed/add-experience-feed.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ExperienceFeedComponent } from './experience-feed.component';

const routes: Routes = [
  { path: '', component: ExperienceFeedComponent },
  { path:'add',component:AddExperienceFeedComponent},
  { path:'get',component:GetExperienceFeedComponent},
  { path:'update',component:UpdateExperienceFeedComponent},

  { path:'**',component:PageNotFoundComponent}
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExperienceFeedRoutingModule { }
