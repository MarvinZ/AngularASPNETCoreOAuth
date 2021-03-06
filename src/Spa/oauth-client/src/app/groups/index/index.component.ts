import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { GroupsService } from '../groups.service';

@Component({
  selector: 'app-groups-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  groups = null;
  busy: boolean;


  // GroupSwitch = 'GROUPLIST';

  showME = true;

  SelectedGroup: number;



  constructor(private authService: AuthService, private service: GroupsService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {

    this.busy = true;
    this.spinner.show();
    this.service.getAllActiveGroups(this.authService.authorizationHeaderValue, this.authService.clientId)
      .pipe(finalize(() => {

        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.groups = result;
        });
  }

  // viewStudents(selectedGroup: number) {
  //   this.SelectedGroup = selectedGroup;
  //   this.getStudentsForGroup(selectedGroup);
  //   this.GroupSwitch = 'VIEWSTUDENTS';

  // }

  // backToGroups() {
  //   this.GroupSwitch = 'GROUPLIST';
  //   this.SelectedGroup = 0;
  // }




}
