import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { ConfigService } from 'src/app/shared/config.service';
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
  imageUrl: any;

  constructor(private authService: AuthService, private service: StudentsService,
    private spinner: NgxSpinnerService, private configService: ConfigService) {
  }

  ngOnInit() {

    this.imageUrl = this.configService.profilePicApiURI;


    this.busy = true;
    this.spinner.show();
    this.service.GetAllStudents(this.authService.authorizationHeaderValue, this.authService.clientId)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.students = result;
        });
  }




}
