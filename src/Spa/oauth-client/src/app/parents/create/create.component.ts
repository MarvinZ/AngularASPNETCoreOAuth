import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { ParentsService } from '../parents.service';



@Component({
  selector: 'app-parents-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})



export class CreateComponent implements OnInit {

  genres: Genre[];

  selectedGenre: Genre;

  busy: boolean;

  dateValue: Date;

  checked: boolean;

  someText: string;

  telephoneInput: number;

  tempResult: any;

  selectedStudent: string;

  newParent: {
    name: string; lastname1: string; lastname2: string; email: string; phone: string; birthday:
    string; genre: any; cedula: string;
  };
  addStudentResult: any;


  constructor(private authService: AuthService, private service: ParentsService, private spinner: NgxSpinnerService,
    private toastr: ToastrService, private router: Router, private route: ActivatedRoute) {

    this.selectedStudent = this.route.snapshot.paramMap.get('studentId');


    this.genres = [
      { name: 'Mujer', code: 'F' },
      { name: 'Hombre', code: 'M' }
    ];


  }

  ngOnInit() {
    this.newParent = {
      name: '',
      lastname1: '',
      lastname2: '',
      phone: '',
      email: '',
      birthday: '',
      genre: '',
      cedula: '000000000',
    };

  }

  addParent() {
    this.busy = true;
    this.spinner.show();
    this.service.addParent(this.authService.authorizationHeaderValue, this.authService.clientId, this.newParent.name,
      this.newParent.lastname1, this.newParent.lastname2, this.newParent.genre.code, this.newParent.birthday,
      this.newParent.email, this.newParent.phone, +this.selectedStudent, this.newParent.cedula.replace('-', '').replace('-', ''))
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.addStudentResult = result;
          this.toastr.success('El encargado se ha creado correctamente', 'ESTUDIANTE');
          this.router.navigateByUrl('/parents');
        });
  }

  GetNameFromCedula() {
    this.service.GetNameFromCedula(this.authService.authorizationHeaderValue, this.authService.clientId,
      this.newParent.cedula.replace('-', '').replace('-', ''))
      .pipe(finalize(() => {

      })).subscribe(
        result => {
          this.tempResult = result;
          this.newParent.name = this.tempResult?.name;
          this.newParent.lastname1 = this.tempResult?.lastName1;
          this.newParent.lastname2 = this.tempResult?.lastName2;

        });
  }

}

interface Genre {
  name: string;
  code: string;
}


