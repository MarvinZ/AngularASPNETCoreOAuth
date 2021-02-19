// import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { TeachersService } from '../teachers.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/app/shared/services/shared.service';
import { ConfigService } from 'src/app/shared/config.service';



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

  genres: Genre[];
  studentGenre = new Genre();
  availableProvinces: Province[];
  selectedProvince: Province;

  allCantons: Canton[];
  availableCantons: any;
  selectedCanton: Canton;

  allDistritos: Distrito[];
  availableDistritos: any;
  selectedDistrito: Distrito;

  fixedDate: Date;

  imageUrl: any;




  @Output() public UploadFinished = new EventEmitter();

  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: TeachersService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService, private configService: ConfigService,
    private sharedService: SharedService) {

    this.genres = [
      { name: 'Mujer', code: 'F' },
      { name: 'Hombre', code: 'M' }
    ];

    this.availableProvinces = this.sharedService.theCatalog.provinces;
    this.allCantons = this.sharedService.theCatalog.cities;
    this.allDistritos = this.sharedService.theCatalog.distritos;

  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedTeacher = this.route.snapshot.paramMap.get('id');

    this.getInitialData();
  }


  getInitialData() {

    this.service.getTeacherDetails(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedTeacher)
      .pipe(finalize(() => {


        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.teacher = result;
          this.fixedDate = new Date(this.teacher.birthday);

          this.imageUrl = this.configService.profilePicApiURI + this.teacher.profilePic;
          this.studentGenre = this.genres.find(x => x.code === this.teacher.genre);
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
    formData.append('TeacherId', this.selectedTeacher);
    formData.append('StudentId', '0');
    formData.append('GroupId', '0');  // 0 means no group, since this is a personal doc
    formData.append('ClientId', this.authService.clientId.toString());  // 0 means no group, since this is a personal doc
    formData.append('IsProfilePic', 'true');  // 0 means no group, since this is a personal doc
    formData.append('PaymentId', '0');  // 0 means no group, since this is a personal doc


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

  UpdateCantones() {
    this.availableCantons = this.allCantons.filter(x => x.stateOrProvinceId === this.selectedProvince.id);
    this.availableDistritos = [];
  }

  UpdateDistritos() {
    this.availableDistritos = this.allDistritos.filter(x => x.cantonId === this.selectedCanton.id);
  }

}




interface Province {
  Name: string;
  id: string;
}

interface Canton {
  Name: string;
  id: string;
  stateOrProvinceId: string;
}

interface Distrito {
  Name: string;
  id: string;
  cantonId: string;
}



export class Genre {
  name: string;
  code: string;
}
