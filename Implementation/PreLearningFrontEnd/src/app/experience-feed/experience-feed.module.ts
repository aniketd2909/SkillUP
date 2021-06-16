import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExperienceFeedRoutingModule } from './experience-feed-routing.module';
import { ExperienceFeedComponent } from './experience-feed.component';
import { AddExperienceFeedComponent } from './add-experience-feed/add-experience-feed.component';
import { GetExperienceFeedComponent } from './get-experience-feed/get-experience-feed.component';
import { UpdateExperienceFeedComponent } from './update-experience-feed/update-experience-feed.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTreeModule } from '@angular/material/tree';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';


@NgModule({
  declarations: [ExperienceFeedComponent, AddExperienceFeedComponent, GetExperienceFeedComponent, UpdateExperienceFeedComponent,  PageNotFoundComponent],
  imports: [
    CommonModule,
    ExperienceFeedRoutingModule,
    FormsModule,   
    ReactiveFormsModule,
    MatTabsModule,
    MatTreeModule,
    MatListModule,
    MatExpansionModule,
    MatDividerModule,
    MatButtonModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule
  ]
})
export class ExperienceFeedModule { }
