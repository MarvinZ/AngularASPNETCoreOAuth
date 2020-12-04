import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from '../shell/shell.service';
import { IndexComponent } from './index/index.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { AuthGuard } from '../core/authentication/auth.guard';

const routes: Routes = [
Shell.childRoutes([
  { path: 'students', component: IndexComponent, canActivate: [AuthGuard] },
  { path: 'addStudent', component: CreateComponent, canActivate: [AuthGuard] },
  { path: 'students/:id', component: DetailsComponent, canActivate: [AuthGuard] }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class StudentsRoutingModule { }
