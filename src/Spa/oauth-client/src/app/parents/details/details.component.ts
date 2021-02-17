// import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { ParentsService } from '../parents.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ConfigService } from 'src/app/shared/config.service';



@Component({
  selector: 'app-parents-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  busy: boolean;
  selectedParent: string;
  parent: any = [];

  public progress: number;
  public message: string;

  submitted = false;
  genres: Genre[];
  parentGenre = new Genre();


  imageUrl: any;

  fixedDate: Date;


  @Output() public UploadFinished = new EventEmitter();

  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: ParentsService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService, private configService: ConfigService) {
  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedParent = this.route.snapshot.paramMap.get('id');
    this.getInitialData();

  }

  getInitialData() {


    this.service.getParentDetails(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedParent)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.parent = result;
          this.fixedDate = new Date(this.parent.birthday);

          this.imageUrl = this.configService.profilePicApiURI + this.parent.profilePic;
          this.parentGenre = this.genres.find(x => x.code === this.parent.genre);
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
    formData.append('StudentId', this.selectedParent);
    formData.append('GroupId', '0');  // 0 means no group, since this is a personal doc

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



export class Genre {
  name: string;
  code: string;
}
