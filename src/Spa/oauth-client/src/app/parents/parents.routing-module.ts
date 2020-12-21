import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from '../shell/shell.service';
import { IndexComponent } from './index/index.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { FinancialComponent } from './financial/financial.component';

import { ExistingParentComponent } from './existing/existing.component';
import { AuthGuard } from '../core/authentication/auth.guard';



const routes: Routes = [
  Shell.childRoutes([
    { path: 'parents', component: IndexComponent, canActivate: [AuthGuard] },
    { path: 'financial/:id', component: FinancialComponent, canActivate: [AuthGuard] },
    { path: 'addParent/:studentId', component: CreateComponent, canActivate: [AuthGuard] },
    { path: 'addExistingParent/:studentId', component: ExistingParentComponent, canActivate: [AuthGuard] },
    { path: 'parents/:id', component: DetailsComponent, canActivate: [AuthGuard] }

  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class ParentsRoutingModule { }
