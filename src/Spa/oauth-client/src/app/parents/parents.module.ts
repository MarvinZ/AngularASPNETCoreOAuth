import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index/index.component';
import { FinancialComponent } from './financial/financial.component';
import { PaymentComponent } from './payment/payment.component';

import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { ExistingParentComponent } from './existing/existing.component';

import { ParentsService } from '../parents/parents.service';

import { ParentsRoutingModule } from './parents.routing-module';

import { FormsModule } from '@angular/forms';

import { SelectButtonModule } from 'primeng/selectbutton';
import {CalendarModule} from 'primeng/calendar';
import {DropdownModule} from 'primeng/dropdown';
import {InputMaskModule} from 'primeng/inputmask';
import {InputSwitchModule} from 'primeng/inputswitch';
import {InputTextModule} from 'primeng/inputtext';
import {InputTextareaModule} from 'primeng/inputtextarea';


@NgModule({
  declarations: [IndexComponent, DetailsComponent, CreateComponent, ExistingParentComponent, FinancialComponent, PaymentComponent],
  providers: [ParentsService],
  imports: [
    CommonModule,
    ParentsRoutingModule,
    SharedModule,
    FormsModule,
    SelectButtonModule, CalendarModule, DropdownModule, InputMaskModule, InputSwitchModule, InputTextModule, InputTextareaModule
  ]
})
export class ParentsModule { }
