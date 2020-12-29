import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { ConfigService } from '../shared/config.service';
import { DecimalPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class StudentsService extends BaseService {



  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  GetAllStudents(token: string, ClientId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetAllStudents', httpOptions).pipe(catchError(this.handleError));
  }


  getStudentDetails(token: string, ClientId: number, StudentId: number) {
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

  addStudent(token: string, ClientId: number, Name: string, Lastname1: string, Lastname2: string, Genre: string, Birthday: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ClientId, Name, Lastname1, Lastname2, Birthday, Genre
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddStudent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }



  RemoveFromGroup(authorizationHeaderValue: string, ClientId: number, GroupId: number, StudentId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, GroupId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/RemoveStudentFromGroup ', payload,
      httpOptions).pipe(catchError(this.handleError));

  }

  RemoveParent(authorizationHeaderValue: string, ClientId: number, ParentId: number, StudentId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, ParentId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/RemoveParentFromStudent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


  Enroll(authorizationHeaderValue: string, ClientId: number, GroupId: number, StudentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, GroupId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddStudentToGroup ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }
  CreateStudentPaymentRequest(authorizationHeaderValue: string, ClientId: number, StudentId: number,
    Amount: number, PaymentRequestTypeId: number, Details: string, Duedate: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, PaymentRequestTypeId, StudentId, Amount, Details, Duedate
    };

    return this.http.post(this.configService.resourceApiURI + '/financial/CreateStudentPaymentRequest ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }

  GetAvailableGroups(token: string, ClientId: number, StudentId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ClientId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/things/GetAvailableGroups',
      payload, httpOptions).pipe(catchError(this.handleError));
  }


  GetAllFinancialsForStudent(token: string, clientId: number, StudentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      clientId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/financial/GetAllFinancialsForStudent',
      payload, httpOptions).pipe(catchError(this.handleError));
  }



  GetStudentActivities(token: string, clientId: number, StudentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      clientId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetStudentActivities',
      payload, httpOptions).pipe(catchError(this.handleError));
  }

}
