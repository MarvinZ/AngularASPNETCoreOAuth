import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { PaymentsService } from '../payments.service';

@Component({
  selector: 'app-payments-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  claims = null;
  busy: boolean;

  constructor(private authService: AuthService, private service: PaymentsService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.service.fetchTopSecretData(this.authService.authorizationHeaderValue, this.authService.clientId)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.claims = result;
        });
  }
}
