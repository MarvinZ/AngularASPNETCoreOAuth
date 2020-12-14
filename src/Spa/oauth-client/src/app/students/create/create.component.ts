import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { StudentsService } from '../students.service';



@Component({
  selector: 'app-students-create',
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
  newStudent: { name: string; lastname1: string; lastname2: string; birthday: string; genre: any; };
  addStudentResult: any;


  constructor(private authService: AuthService, private service: StudentsService, private spinner: NgxSpinnerService,
              private toastr: ToastrService, private router: Router) {

    this.genres = [
      { name: 'Niña', code: 'F' },
      { name: 'Niño', code: 'M' }
    ];


  }

  ngOnInit() {
    this.newStudent = {
      name: '',
      lastname1: '',
      lastname2: '',
      birthday: '',
      genre: []
    };

  }

  addStudent() {
    this.busy = true;
    this.spinner.show();
    this.service.addStudent(this.authService.authorizationHeaderValue, this.authService.clientId,  this.newStudent.name,
      this.newStudent.lastname1, this.newStudent.lastname2, this.newStudent.genre.code, this.newStudent.birthday)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.addStudentResult = result;
          this.toastr.success('El estudiante se ha creado correctamente', 'ESTUDIANTE');
          this.router.navigateByUrl('/students');

        });
  }


}

interface Genre {
  name: string;
  code: string;
}


