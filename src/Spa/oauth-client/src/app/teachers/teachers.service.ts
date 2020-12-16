import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { ConfigService } from '../shared/config.service';

@Injectable({
  providedIn: 'root'
})

export class TeachersService extends BaseService {


  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  GetAllTeachers(token: string, ClientId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetAllTeachers', httpOptions).pipe(catchError(this.handleError));
  }


  getTeacherDetails(token: string, ClientId: number, TeacherId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      TeacherId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/getTeacherDetails', payload,
      httpOptions).pipe(catchError(this.handleError));
  }

  addTeacher(token: string, ClientId: number, Name: string, Lastname1: string, Lastname2: string, Genre: string,
             Birthday: string, Email: string, Phone: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ClientId, Name, Lastname1, Lastname2, Birthday, Email, Phone
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddTeacher ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }

  GetNameFromCedula(token: string, ClientId: number, Cedula: string) {
    console.log(Cedula);


    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      Cedula: +Cedula
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetNameFromCedula ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }



}
