import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { DeleteExperienceFeedComponent } from './delete-experience-feed/delete-experience-feed.component';
import { UpdateExperienceFeedComponent } from './update-experience-feed/update-experience-feed.component';
import { GetExperienceFeedComponent } from './get-experience-feed/get-experience-feed.component';
import { AddExperienceFeedComponent } from './add-experience-feed/add-experience-feed.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ExperienceFeedComponent } from './experience-feed.component';

const routes: Routes = [
  { path: '', component: ExperienceFeedComponent },
  { path:'add-feed',component:AddExperienceFeedComponent},
  { path:'get-feed',component:GetExperienceFeedComponent},
  { path:'update-feed',component:UpdateExperienceFeedComponent},
  { path:'delete-feed',component:DeleteExperienceFeedComponent},

  { path:'**',component:PageNotFoundComponent}
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExperienceFeedRoutingModule { }
