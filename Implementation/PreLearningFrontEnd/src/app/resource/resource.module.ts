import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResourceRoutingModule } from './resource-routing.module';
import { ResourceComponent } from './resource.component';
import { ListTopicComponent } from './list-topic/list-topic.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatTreeModule} from '@angular/material/tree';
import { MatListModule } from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptorService } from 'src/services/token-interceptor.service';


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
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
})
export class ResourceModule { }
