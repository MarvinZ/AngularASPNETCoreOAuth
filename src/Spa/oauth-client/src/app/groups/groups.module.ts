import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index/index.component';
import { DetailsComponent } from './details/details.component';
import { GroupsService } from '../groups/groups.service';
import { CreateComponent } from './create/create.component';


import { GroupsRoutingModule } from './groups.routing-module';

import { FormsModule } from '@angular/forms';

import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import {CardModule} from 'primeng/card';
import { InputNumberModule } from 'primeng/inputnumber';





@NgModule({
  declarations: [IndexComponent, DetailsComponent, CreateComponent],
  providers: [GroupsService],
  imports: [
    CommonModule,
    GroupsRoutingModule,
    SharedModule,
    FormsModule,
    DropdownModule, CalendarModule, CardModule, InputNumberModule
  ]
})
export class GroupsModule { }
