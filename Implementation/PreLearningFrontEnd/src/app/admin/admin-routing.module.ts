import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUserDetailsComponent } from './add-user-details/add-user-details.component';
import { AdminComponent } from './admin.component';

const routes: Routes = [{ path: '', component: AdminComponent },
{ path: 'add-user', component: AddUserDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
