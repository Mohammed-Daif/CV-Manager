import { ListComponent } from './modules/cv-module/Pages/list/list.component';
import { NotfoundComponent } from './core/pages/notfound/notfound.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'cv',
    loadChildren: () =>
      import('./modules/cv-module/cv-module.module').then((m) => m.CvModule),
  },
  { path: 'NotFound', component: NotfoundComponent },
  { path: '', pathMatch: 'full', redirectTo: 'cv' },
  { path: '**', pathMatch: 'full', redirectTo: 'NotFound' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
