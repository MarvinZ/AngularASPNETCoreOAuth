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

  openGroupResult: any = [];


  constructor(private authService: AuthService, private service: GroupsService, private spinner: NgxSpinnerService,
              private sharedservice: SharedService, private toastr: ToastrService, private router: Router) {
  }

  ngOnInit() {

    this.testMe = this.sharedservice.theCatalog;
    this.levels = this.sharedservice.theCatalog.levels;
    this.cycles = this.sharedservice.theCatalog.cycles;
    this.busy = true;
    this.spinner.show();
    this.spinner.hide();
    this.busy = false;
    this.newGroup = {
      name: '',
      cycleId: null,
      levelId: null
    };

  }


  openGroup() {

    this.busy = true;
    this.spinner.show();
    this.service.openGroup(this.authService.authorizationHeaderValue, +this.newGroup.cycleId, +this.newGroup.levelId, this.newGroup.name)
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
