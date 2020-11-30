import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-students-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  students = null;
  busy: boolean;
  STATE = 'SEARCH_STUDENT';

  constructor(private authService: AuthService, private service: StudentsService, private spinner: NgxSpinnerService) {
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
          this.students = result;
        });
  }


  cancelCreateStudent() {
    this.STATE = 'SEARCH_STUDENT';
   }

   openCreateStudent() {
    this.STATE = 'CREATE_STUDENT';
   }

}
