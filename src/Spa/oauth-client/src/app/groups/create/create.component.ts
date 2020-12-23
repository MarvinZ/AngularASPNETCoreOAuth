import { UserManagerSettings } from 'oidc-client';
import { SharedService } from './../../shared/services/shared.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { GroupsService } from '../groups.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-groups-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {


  busy: boolean;

  testMe: any;

  newGroup: any = [];

  levels: any = [];
  cycles: any = [];
  paymentTypes: any = [];
  activityTypes: any = [];

  openGroupResult: any = [];


  constructor(private authService: AuthService, private service: GroupsService, private spinner: NgxSpinnerService,
    private sharedservice: SharedService, private toastr: ToastrService, private router: Router) {
  }

  ngOnInit() {

    this.testMe = this.sharedservice.theCatalog;
    this.levels = this.sharedservice.theCatalog.levels;
    this.cycles = this.sharedservice.theCatalog.cycles;
    this.paymentTypes = this.sharedservice.theCatalog.paymentTypes;
    this.activityTypes = this.sharedservice.theCatalog.activityTypes;
    this.busy = true;
    this.spinner.show();
    this.spinner.hide();
    this.busy = false;
    this.newGroup = {
      name: '',
      cycleId: null,
      levelId: null,
      minDate: new Date('02 - 15 - 2020'),
      maxDate: new Date('02 - 15 - 2020')
    };

  }


  openGroup() {

    this.busy = true;
    this.spinner.show();
    this.service.openGroup(this.authService.authorizationHeaderValue, this.authService.clientId,
      +this.newGroup.cycleId, +this.newGroup.levelId, this.newGroup.name, this.newGroup.minDate, this.newGroup.maxDate)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.openGroupResult = result;
          this.toastr.success('El grupo se ha creado correctamente', 'GRUPO');
          this.router.navigateByUrl('/groups');

        });
  }


}
