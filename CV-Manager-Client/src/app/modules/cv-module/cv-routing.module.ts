import { CvFormComponent } from './Pages/cv-form/cv-form.component';
import { ViewComponent } from './Pages/view/view.component';

import { ListComponent } from './Pages/list/list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: ListComponent,
  },
  { path: 'view/:id', component: ViewComponent },
  { path: 'edit/:id', component: CvFormComponent },
  { path: 'create', component: CvFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CVRoutingModule {}
