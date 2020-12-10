// import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr'; import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { GroupsService } from '../groups.service';

import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-group-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  busy: boolean;
  selectedGroup: string;
  group: any;
  students = null;
  openAddTeacherToGroup = false;

  availableTeachers: AvailableTeacher[];


  selectedTeacher: AvailableTeacher;

  executionResult: any;


  public progress: number;
  public message: string;
  @Output() public UploadFinished = new EventEmitter();


  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: GroupsService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService, private router: Router) {

    this.availableTeachers = [
      { name: 'MArio Corrales', code: '11' },
      { name: 'Tatiana malavassi', code: '77' }
    ];

  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedGroup = this.route.snapshot.paramMap.get('id');

    this.getInitialData();

    this.spinner.hide();
    this.busy = false;

  }

  getInitialData() {
    this.service.getGroupDetails(this.authService.authorizationHeaderValue, +this.selectedGroup)
      .pipe(finalize(() => {

        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.group = result;
        });

    this.getStudentsForGroup(+this.selectedGroup);
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    const fileToUpload = files[0] as File;
    const formData = new FormData();
    formData.append('GroupId', this.selectedGroup);
    formData.append('StudentId', '0');  // 0 means no student, since this is a personal doc

    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post('http://localhost:5050/api/Upload', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.UploadFinished.emit(event.body);
        }
      });
  }

  getStudentsForGroup(selectedGroup: number) {
    this.busy = true;
    this.spinner.show();
    this.service.getStudentsForGroup(this.authService.authorizationHeaderValue, selectedGroup)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.students = result;
        });
  }

  AddTeacherToGroup() {
    console.log(this.selectedTeacher);
  }

  RemoveFromGroup(id: string) {
    this.service.RemoveFromGroup(this.authService.authorizationHeaderValue, +this.selectedGroup, +id)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          console.log('ahora siii');
          console.log(this.executionResult);
          if (this.executionResult) {
            this.toastr.success('El estudiante ha sido removido del grupo', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });
  }


}

interface AvailableTeacher {
  name: string;
  code: string;
}
