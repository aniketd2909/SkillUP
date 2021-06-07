import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import { BlockerRoutingModule } from './blocker-routing.module';
import { BlockerComponent } from './blocker.component';
import { ListBlockerComponent } from './list-blocker/list-blocker.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTreeModule } from '@angular/material/tree';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptorService } from 'src/services/token-interceptor.service';
import {MatDividerModule} from '@angular/material/divider';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddSolutionComponent } from './add-solution/add-solution.component';
import {MatCardModule} from '@angular/material/card';
import { AddBlockerComponent } from './add-blocker/add-blocker.component';
@NgModule({
  declarations: [
    BlockerComponent,
    ListBlockerComponent,
    AddSolutionComponent,
    AddBlockerComponent
  ],
  imports: [
    CommonModule,
    BlockerRoutingModule,
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
    FormsModule,
    ReactiveFormsModule,
    MatCardModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
})
export class BlockerModule { }
