// import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr'; import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { GroupsService } from '../groups.service';

import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { SharedService } from 'src/app/shared/services/shared.service';


@Component({
  selector: 'app-group-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss']
})
export class ActivityComponent implements OnInit {

  busy: boolean;
  selectedGroup: string;
  group: any = [];
  students = null;
  openAddTeacherToGroup = false;

  availableActivityTypes: ActivityType[];
  selectedActivityType: ActivityType;

  executionResult: any;
  newAcivity = false;

  Amount = 0;

  paymentDetails = '';

  dueDate = '2012-12-31';

  public progress: number;
  public message: string;
  @Output() public UploadFinished = new EventEmitter();



  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: GroupsService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService, private router: Router,
    private sharedService: SharedService) {
      console.log(this.sharedService.theCatalog);

    this.availableActivityTypes = this.sharedService.theCatalog.activityTypes;
  }


  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedGroup = this.route.snapshot.paramMap.get('id');
    this.getInitialData();
  }


  getInitialData() {
    this.service.getGroupDetails(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedGroup)
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
    this.service.getStudentsForGroup(this.authService.authorizationHeaderValue, this.authService.clientId, selectedGroup)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.students = result;
        });
  }




  RemoveStudentFromGroupActivity(id: string) {

  }


  OpenNewActivity() {
    this.newAcivity = true;
  }


  CloseNewActivity() {
    this.newAcivity = false;
  }


  CreateNewGroupActivity() {
    this.service.CreateNewGroupActivity(this.authService.authorizationHeaderValue, this.authService.clientId,
      +this.selectedGroup, this.Amount, +this.selectedActivityType.id, this.paymentDetails, this.dueDate)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('La actividad ha sido creada para el grupo', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });

  }


}


interface ActivityType {
  name: string;
  id: string;
}
