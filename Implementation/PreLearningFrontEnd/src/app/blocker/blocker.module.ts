import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlockerRoutingModule } from './blocker-routing.module';
import { BlockerComponent } from './blocker.component';
import { AddblockerComponent } from './addblocker/addblocker.component';


@NgModule({
  declarations: [BlockerComponent, AddblockerComponent],
  imports: [
    CommonModule,
    BlockerRoutingModule
  ]
})
export class BlockerModule { }
