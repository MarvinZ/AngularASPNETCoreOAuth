// import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { StudentsService } from '../students.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ConfigService } from 'src/app/shared/config.service';
import { SharedService } from 'src/app/shared/services/shared.service';



@Component({
  selector: 'app-students-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  busy: boolean;
  selectedStudent: string;
  student: any = [];

  public progress: number;
  public message: string;

  submitted = false;
  openAddToGroup = false;
  availableGroups: AvailableGroup[];
  selectedGroup: AvailableGroup;


  availablePaymentTypes: any = [];
  executionResult: any = [];

  displayUploadPicControls = false;

  tableItems: any = [];

  CreatePaymentRequest = false;

  selectedPaymentType = [];

  Amount = 0;

  paymentDetails = '';

  dueDate = '2012-12-31';
  imageUrl: any;

  @Output() public UploadFinished = new EventEmitter();



  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: StudentsService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService, private configService: ConfigService,
    private sharedService: SharedService) {

    this.availableGroups = [];
    this.availablePaymentTypes = this.sharedService.theCatalog.paymentTypes;

  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedStudent = this.route.snapshot.paramMap.get('id');

    this.getInitialData();



  }

  getInitialData() {
    this.GetStudentDetails();
    this.GetStudentFinancialInformation();
  }

  GetStudentDetails() {
    this.service.getStudentDetails(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedStudent)
      .pipe(finalize(() => {

        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.student = result;
          this.imageUrl = this.configService.profilePicApiURI + this.student.profilePic;

          this.spinner.hide();
          this.busy = false;
        });
  }

  GetAvailableGroups() {
    this.service.GetAvailableGroups(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedStudent)
      .pipe(finalize(() => {

        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.availableGroups = result as AvailableGroup[];
          this.spinner.hide();
          this.busy = false;
        });
  }

  GetStudentFinancialInformation() {
    this.service.GetAllFinancialsForStudent(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedStudent)
      .pipe(finalize(() => {


      })).subscribe(
        result => {
          this.tableItems = result;

        });
  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    const fileToUpload = files[0] as File;
    const formData = new FormData();
    formData.append('StudentId', this.selectedStudent);
    formData.append('GroupId', '0');  // 0 means no group, since this is a personal doc
    formData.append('ClientId', this.authService.clientId.toString());  // 0 means no group, since this is a personal doc
    formData.append('IsProfilePic', 'true');  // 0 means no group, since this is a personal doc

    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post('http://localhost:5050/api/Upload', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.UploadFinished.emit(event.body);
          this.getInitialData();
        }
      });
  }

  onSubmit() { this.submitted = true; }


  Enroll() {
    this.service.Enroll(this.authService.authorizationHeaderValue, this.authService.clientId,
      +this.selectedGroup.id, +this.selectedStudent)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('El estudiante ha sido agregado al grupo', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });
  }

  RemoveParent(id: string) {

    this.service.RemoveParent(this.authService.authorizationHeaderValue, this.authService.clientId, +id, +this.selectedStudent)
      .pipe(finalize(() => {

        // this.spinner.hide();
        // this.busy = false;
      })).subscribe(
        result => {
          this.executionResult = result;
          if (this.executionResult) {
            this.toastr.success('El encargado ha sido removido del estudiante', '!Éxito!');
            this.getInitialData();
          } else {
            this.toastr.error('errorrrrr', 'ERROR');
            this.getInitialData();
          }
        });

  }


  RemoveFromGroup(id: string) {
    this.service.RemoveFromGroup(this.authService.authorizationHeaderValue, this.authService.clientId, +id, +this.selectedStudent)
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


  replaceProfilePic() {
    this.displayUploadPicControls = true;
  }

  OpenCreatePaymentRequest() {
    this.CreatePaymentRequest = true;

  }



  CancelPaymentRequest() {
    this.CreatePaymentRequest = false;
    this.Amount = 999;
    this.selectedPaymentType = [];
    this.dueDate = '2012-12-31';
  }


  CreateStudentPaymentRequest() {
    this.service.CreateStudentPaymentRequest(this.authService.authorizationHeaderValue, this.authService.clientId,
      +this.selectedStudent, this.Amount, +this.selectedPaymentType.id, this.paymentDetails, this.dueDate)
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

interface AvailableGroup {
  GroupShortname: string;
  id: string;
}
