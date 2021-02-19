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
  selector: 'app-parents-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  busy: boolean;

  parent: any = [];

  public progress: number;
  public message: string;

  submitted = false;

  thePayment: any;

  selectedPaymentId: any;
  selectedParentId: any;


  imageUrl: any;



  @Output() public UploadFinished = new EventEmitter();

  constructor(private route: ActivatedRoute, private authService: AuthService,
    private service: ParentsService, private spinner: NgxSpinnerService,
    private http: HttpClient, private toastr: ToastrService,
    private configService: ConfigService) {
  }

  ngOnInit() {
    this.busy = true;
    this.spinner.show();
    this.selectedPaymentId = this.route.snapshot.paramMap.get('id2');
    this.selectedParentId = this.route.snapshot.paramMap.get('id');

    this.GetPaymentDetails();

  }


  onSubmit() { this.submitted = true; }



  GetPaymentDetails() {
    this.service.GetPaymentDetails(this.authService.authorizationHeaderValue, this.authService.clientId, +this.selectedPaymentId)
      .pipe(finalize(() => {


      })).subscribe(
        result => {
          this.thePayment = result;
          this.spinner.hide();
          this.busy = false;
          this.imageUrl = this.configService.profilePicApiURI + this.thePayment.paymentAttachment;

        });
  }

  Pay(paymentRequest: number) {
    this.service.Pay(this.authService.authorizationHeaderValue, this.authService.clientId, +this.thePayment.parentId, paymentRequest)
      .pipe(finalize(() => {


      })).subscribe(
        result => {
          this.thePayment = result;
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
    formData.append('StudentId', '0');
    formData.append('PaymentId', this.selectedPaymentId);  // 0 means no group, since this is a personal doc
    formData.append('GroupId', '0');  // 0 means no group, since this is a personal doc
    formData.append('TeacherId', '0');  // 0 means no group, since this is a personal doc
    formData.append('ClientId', this.authService.clientId.toString());  // 0 means no group, since this is a personal doc
    formData.append('IsProfilePic', 'false');  // 0 means no group, since this is a personal doc

    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post('http://localhost:5050/api/Upload', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.UploadFinished.emit(event.body);
          this.GetPaymentDetails();
        }
      });
  }

}
