import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { IndexComponent } from './index/index.component';

import { PaymentsService } from '../payments/payments.service';

import { PaymentsRoutingModule } from './payments.routing-module';

@NgModule({
  declarations: [IndexComponent],
  providers: [PaymentsService],
  imports: [
    CommonModule,
    PaymentsRoutingModule,
    SharedModule
  ]
})
export class PaymentsModule { }
