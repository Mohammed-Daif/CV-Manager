import { TableComponent } from './../../core/components/table/table.component';
import { NgModule } from '@angular/core';
import { ListComponent } from './Pages/list/list.component';

import { CVRoutingModule } from './cv-routing.module';
import {MessageModule} from 'primeng/message';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { ViewComponent } from './Pages/view/view.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import { CvFormComponent } from './Pages/cv-form/cv-form.component';

@NgModule({
  declarations: [ListComponent, ViewComponent, CvFormComponent],
  imports: [
    TableComponent,
    CVRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    CommonModule,
    MessageModule,
    ConfirmDialogModule,
    
  ],
})
export class CvModule {}
