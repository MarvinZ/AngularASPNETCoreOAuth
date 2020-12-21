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
  selector: 'app-group-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  busy: boolean;
  selectedGroup: string;
  group: any = [];
  students = null;
  openAddTeacherToGroup = false;

  availableTeachers: AvailableTeacher[] = [];

  availablePaymentTypes: PaymentType[];
  selectedPaymentType: PaymentType;


  selectedTeacher: AvailableTeacher;

  executionResult: any;
  paymentRequest = false;

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

    this.availableTeachers = [];
    this.availablePaymentTypes = this.sharedService.theCatalog.paymentTypes;


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
    this.getAllAvailableTeachers(+this.selectedGroup);
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



  getAllAvailableTeachers(selectedGroup: number) {
    this.busy = true;
    this.spinner.show();
    this.service.getAllAvailableTeachers(this.authService.authorizationHeaderValue, this.authService.clientId, +selectedGroup)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {


          this.availableTeachers = result as AvailableTeacher[];
        });
  }


  AddTeacherToGroup() {
    this.service.AddTeacherToGroup(this.authService.authorizationHeaderValue,
      this.authService.clientId, +this.selectedGroup, +this.selectedTeacher.id)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('La teacher ha sido agregada al grupo', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });

  }

  RemoveStudentFromGroup(id: string) {
    this.service.RemoveStudentFromGroup(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedGroup, +id)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('El estudiante ha sido removido del grupo', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });
  }

  RemoveTeacherFromGroup(id: string) {
    this.service.RemoveTeacherFromGroup(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedGroup, +id)
      .pipe(finalize(() => {
        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('El teacher ha sido removido del grupo', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });
  }

  OpenPaymentRequest() {
    this.paymentRequest = true;
  }
  ClosePaymentRequest() {
    this.paymentRequest = false;
  }


  CreateGroupPaymentRequest() {
    this.service.CreateGroupPaymentRequest(this.authService.authorizationHeaderValue, this.authService.clientId,
      +this.selectedGroup, this.Amount, +this.selectedPaymentType.id, this.paymentDetails, this.dueDate)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('El cobreo ha sido agregado para el estudiante', '!Éxito!');
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
  id: string;
}

interface PaymentType {
  GroupShortname: string;
  id: string;
}
