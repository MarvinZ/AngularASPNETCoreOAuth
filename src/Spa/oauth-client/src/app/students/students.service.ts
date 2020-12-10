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

  addStudent(token: string, Name: string, Lastname1: string, Lastname2: string, Genre: string, Birthday: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      Name, Lastname1, Lastname2, Birthday
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddStudent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }



  RemoveFromGroup(authorizationHeaderValue: string, GroupId: string, StudentId: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      GroupId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/RemoveStudentFromGroup ', payload,
      httpOptions).pipe(catchError(this.handleError));

  }

  RemoveParent(authorizationHeaderValue: string, ParentId: string, StudentId: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ParentId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/RemoveParentFromStudent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


  Enroll(authorizationHeaderValue: string, GroupId: string, StudentId: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      GroupId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddStudentToGroup ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }







}
