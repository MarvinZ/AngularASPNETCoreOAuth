// import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { TeachersService } from '../teachers.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-teachers-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  busy: boolean;
  selectedTeacher: string;
  teacher: any = [];

  public progress: number;
  public message: string;

  submitted = false;


  @Output() public UploadFinished = new EventEmitter();

  constructor(private route: ActivatedRoute, private authService: AuthService,
              private service: TeachersService, private spinner: NgxSpinnerService,
              private http: HttpClient, private toastr: ToastrService) {
  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedTeacher = this.route.snapshot.paramMap.get('id');

    this.service.getTeacherDetails(this.authService.authorizationHeaderValue, +this.selectedTeacher)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.teacher = result;
        });



    this.spinner.hide();
    this.busy = false;



  }

  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    const fileToUpload = files[0] as File;
    const formData = new FormData();
    formData.append('StudentId', this.selectedTeacher);
    formData.append('GroupId', '0');  // 0 means no group, since this is a personal doc

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

  onSubmit() { this.submitted = true; }

}
