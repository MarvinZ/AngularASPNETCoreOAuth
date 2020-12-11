import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { TeachersService } from '../teachers.service';



@Component({
  selector: 'app-teachers-create',
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
  newTeacher: {
    name: string; lastname1: string; lastname2: string; birthday: string; genre: string;
    email: string; phone: string; cedula: string;
  };
  addStudentResult: any;
  tempResult: any;


  constructor(private authService: AuthService, private service: TeachersService, private spinner: NgxSpinnerService,
    private toastr: ToastrService, private router: Router) {

    this.genres = [
      { name: 'Mujer', code: 'F' },
      { name: 'Hombre', code: 'M' }
    ];

  }

  ngOnInit() {
    this.newTeacher = {
      name: '',
      lastname1: '',
      lastname2: '',
      birthday: '',
      genre: '',
      email: '',
      phone: '',
      cedula: ''
    };

  }

  addTeacher() {
    this.busy = true;
    this.spinner.show();
    this.service.addTeacher(this.authService.authorizationHeaderValue, this.newTeacher.name,
      this.newTeacher.lastname1, this.newTeacher.lastname2, this.newTeacher.genre, this.newTeacher.birthday,
      this.newTeacher.email, this.newTeacher.phone)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.addStudentResult = result;
          this.toastr.success('El teacher se ha creado correctamente', 'ESTUDIANTE');
          this.router.navigateByUrl('/teachers');

        });
  }


  GetNameFromCedula() {
    this.service.GetNameFromCedula(this.authService.authorizationHeaderValue, this.newTeacher.cedula.replace('-', '').replace('-', ''))
      .pipe(finalize(() => {

      })).subscribe(
        result => {
          this.tempResult = result;
          console.log(this.tempResult);
          this.newTeacher.name = this.tempResult?.name;
          this.newTeacher.lastname1 = this.tempResult?.lastName1;
          this.newTeacher.lastname2 = this.tempResult?.lastName2;

        });
  }


}

interface Genre {
  name: string;
  code: string;
}


