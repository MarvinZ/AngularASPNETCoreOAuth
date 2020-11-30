import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index/index.component';

import { StudentsService } from '../students/students.service';

import { StudentsRoutingModule } from './students.routing-module';

@NgModule({
  declarations: [IndexComponent],
  providers: [StudentsService],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule
  ]
})
export class StudentsModule { }
