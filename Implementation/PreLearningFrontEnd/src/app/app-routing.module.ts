import { NgModule } from '@angular/core';
import { MatListModule } from '@angular/material/list';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'experience-feed',
    loadChildren: () =>
      import('./experience-feed/experience-feed.module').then(
        (m) => m.ExperienceFeedModule
      ),
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  {
    path: 'resource',
    loadChildren: () =>
      import('./resource/resource.module').then((m) => m.ResourceModule),
  },
  { path: 'bestPractises', loadChildren: () => import('./best-practises/best-practises.module').then(m => m.BestPractisesModule) },
  {
    path: 'blocker',
    loadChildren: () =>
      import('./blocker/blocker.module').then((m) => m.BlockerModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
