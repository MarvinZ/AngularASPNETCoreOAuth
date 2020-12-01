import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { ConfigService } from '../shared/config.service';

@Injectable({
  providedIn: 'root'
})

export class StudentsService extends BaseService {

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  fetchTopSecretData(token: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetAllStudents', httpOptions).pipe(catchError(this.handleError));
  }


  getStudentDetails(token: string, StudentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetStudentDetails', payload,
      httpOptions).pipe(catchError(this.handleError));
  }



}
