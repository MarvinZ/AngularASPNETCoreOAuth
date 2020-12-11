import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { ParentsService } from '../parents.service';



@Component({
  selector: 'app-parents-existing',
  templateUrl: './existing.component.html',
  styleUrls: ['./existing.component.scss']
})



export class  ExistingParentComponent implements OnInit {

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
    string; genre: string; cedula: string;
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
    this.service.addParent(this.authService.authorizationHeaderValue, this.newParent.name,
      this.newParent.lastname1, this.newParent.lastname2, this.newParent.genre, this.newParent.birthday,
      this.newParent.email, this.newParent.phone, +this.selectedStudent)
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




  GetExistingNameFromCedula() {
    this.service.GetExistingNameFromCedula(this.authService.authorizationHeaderValue,
      this.newParent.cedula.replace('-', '').replace('-', ''))
      .pipe(finalize(() => {

      })).subscribe(
        result => {
          this.tempResult = result;
          console.log(this.tempResult);
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


