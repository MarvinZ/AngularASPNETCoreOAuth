import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { TeachersService } from '../teachers.service';

@Component({
  selector: 'app-teachers-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  teachers = null;
  busy: boolean;

  constructor(private authService: AuthService, private service: TeachersService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {

    this.busy = true;
    this.spinner.show();
    this.service.GetAllTeachers(this.authService.authorizationHeaderValue, this.authService.clientId)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.teachers = result;
        });
  }




}
