import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from '../shell/shell.service';
import { IndexComponent } from './index/index.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { ActivityComponent } from './activity/activity.component';



import { AuthGuard } from '../core/authentication/auth.guard';

const routes: Routes = [
Shell.childRoutes([
  { path: 'groups', component: IndexComponent, canActivate: [AuthGuard] },
  { path: 'groups/:id', component: DetailsComponent, canActivate: [AuthGuard] },
  { path: 'group_activities/:id', component: ActivityComponent, canActivate: [AuthGuard] },
  { path: 'openGroup', component: CreateComponent, canActivate: [AuthGuard] }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class GroupsRoutingModule { }
