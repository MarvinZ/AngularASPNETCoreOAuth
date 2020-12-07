import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators';
import { AuthService } from '../../core/authentication/auth.service';
import { StudentsService } from '../students.service';



@Component({
  selector: 'app-students-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})




export class CreateComponent implements OnInit {

  cities: City[];

  selectedCity: City;

  busy: boolean;




  constructor(private authService: AuthService, private service: StudentsService, private spinner: NgxSpinnerService) {

    this.cities = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' }
    ];


  }

  ngOnInit() {

    this.busy = true;
    this.spinner.show();
    this.spinner.hide();
    this.busy = false;

  }



}

interface City {
  name: string;
  code: string;
}


