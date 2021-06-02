import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceComponent } from './resource.component';
import { ListTopicComponent } from './list-topic/list-topic.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTreeModule} from '@angular/material/tree';
import { MatListModule } from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';


@NgModule({
  declarations: [
    ResourceComponent,
    ListTopicComponent
  ],
  imports: [
    CommonModule,
    ResourceRoutingModule,
    MatTabsModule,
    MatTreeModule,
    MatListModule,
    MatExpansionModule
  ]
})
export class ResourceModule { }
