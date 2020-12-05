import { SharedService } from './../../shared/services/shared.service';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { GroupsService } from '../groups.service';

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


  constructor(private authService: AuthService, private service: GroupsService, private spinner: NgxSpinnerService,
              private sharedservice: SharedService) {
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
      name: 'some group name that is hardcoded',
      cycleId: 1,
      levelId: 1
    };

  }



}
