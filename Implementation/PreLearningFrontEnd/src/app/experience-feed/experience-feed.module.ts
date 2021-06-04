import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExperienceFeedRoutingModule } from './experience-feed-routing.module';
import { ExperienceFeedComponent } from './experience-feed.component';
import { AddExperienceFeedComponent } from './add-experience-feed/add-experience-feed.component';
import { GetExperienceFeedComponent } from './get-experience-feed/get-experience-feed.component';
import { UpdateExperienceFeedComponent } from './update-experience-feed/update-experience-feed.component';
import { DeleteExperienceFeedComponent } from './delete-experience-feed/delete-experience-feed.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [ExperienceFeedComponent, AddExperienceFeedComponent, GetExperienceFeedComponent, UpdateExperienceFeedComponent, DeleteExperienceFeedComponent, PageNotFoundComponent],
  imports: [
    CommonModule,
    ExperienceFeedRoutingModule,
    FormsModule,   
    ReactiveFormsModule
  ]
})
export class ExperienceFeedModule { }
