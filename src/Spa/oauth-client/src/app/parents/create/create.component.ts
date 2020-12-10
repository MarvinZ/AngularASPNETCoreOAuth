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



  selectedStudent: string;

  newParent: { name: string; lastname1: string; lastname2: string; email: string; phone: string; birthday: string; genre: string; };
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
      genre: ''
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


}

interface Genre {
  name: string;
  code: string;
}


