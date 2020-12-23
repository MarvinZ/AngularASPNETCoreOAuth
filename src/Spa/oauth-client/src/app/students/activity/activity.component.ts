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
export class ActivityComponent implements OnInit {

  busy: boolean;
  selectedStudent: string;


  public progress: number;
  public message: string;

  submitted = false;


  executionResult: any = [];

  displayUploadPicControls = false;

  activities: any = [];



  @Output() public UploadFinished = new EventEmitter();



  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: StudentsService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService, private configService: ConfigService,
    private sharedService: SharedService) {



  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedStudent = this.route.snapshot.paramMap.get('id');

    this.getInitialData();



  }

  getInitialData() {
    this.GetStudentActivities();

  }

  GetStudentDetails() {
    this.service.GetStudentActivities(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedStudent)
      .pipe(finalize(() => {

        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.activities = result;

          this.spinner.hide();
          this.busy = false;
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




}

