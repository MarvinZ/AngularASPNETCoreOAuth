import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index/index.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';

import { TeachersService } from '../teachers/teachers.service';

import { StudentsRoutingModule } from './teachers.routing-module';

import { FormsModule } from '@angular/forms';

import { SelectButtonModule } from 'primeng/selectbutton';
import {CalendarModule} from 'primeng/calendar';
import {DropdownModule} from 'primeng/dropdown';
import {InputMaskModule} from 'primeng/inputmask';
import {InputSwitchModule} from 'primeng/inputswitch';
import {InputTextModule} from 'primeng/inputtext';
import {InputTextareaModule} from 'primeng/inputtextarea';







@NgModule({
  declarations: [IndexComponent, DetailsComponent, CreateComponent],
  providers: [TeachersService],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule,
    FormsModule,
    SelectButtonModule, CalendarModule, DropdownModule, InputMaskModule, InputSwitchModule, InputTextModule, InputTextareaModule
  ]
})
export class TeachersModule { }
