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

  claims = null;
  busy: boolean;

  constructor(private authService: AuthService, private service: GroupsService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {
    console.log('aqui van los...');
    this.busy = true;
    this.spinner.show();
    this.service.fetchTopSecretData(this.authService.authorizationHeaderValue)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.claims = result;
        });
  }
}
