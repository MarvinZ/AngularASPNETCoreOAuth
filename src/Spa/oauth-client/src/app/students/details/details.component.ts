import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { StudentsService } from '../students.service';

@Component({
  selector: 'app-students-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  busy: boolean;
  selectedStudent: string;
  student: any;

  constructor(private route: ActivatedRoute, private authService: AuthService,
              private service: StudentsService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedStudent = this.route.snapshot.paramMap.get('id');

    this.service.getStudentDetails(this.authService.authorizationHeaderValue, +this.selectedStudent)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.student = result;
        });



    this.spinner.hide();
    this.busy = false;

  }



}
