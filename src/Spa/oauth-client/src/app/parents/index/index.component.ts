import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { ParentsService } from '../parents.service';

@Component({
  selector: 'app-parents-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  parents = null;
  busy: boolean;

  constructor(private authService: AuthService, private service: ParentsService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {

    this.busy = true;
    this.spinner.show();
    this.service.GetAllParents(this.authService.authorizationHeaderValue, this.authService.clientId)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.parents = result;
        });
  }




}
