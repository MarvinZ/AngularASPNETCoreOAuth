import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index/index.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';

import { StudentsService } from '../students/students.service';

import { StudentsRoutingModule } from './students.routing-module';

import { FormsModule } from '@angular/forms';

import { SelectButtonModule } from 'primeng/selectbutton';

import { ButtonModule } from 'primeng/button';


@NgModule({
  declarations: [IndexComponent, DetailsComponent, CreateComponent],
  providers: [StudentsService],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule,
    FormsModule,
    SelectButtonModule, ButtonModule
  ]
})
export class StudentsModule { }
