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




  constructor(private authService: AuthService, private service: GroupsService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {

    this.busy = true;
    this.spinner.show();
    this.spinner.hide();
    this.busy = false;

  }



}
