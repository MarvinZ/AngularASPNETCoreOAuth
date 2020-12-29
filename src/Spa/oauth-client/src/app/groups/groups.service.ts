import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { ConfigService } from '../shared/config.service';

@Injectable({
  providedIn: 'root'
})

export class GroupsService extends BaseService {

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  getAllActiveGroups(token: string, ClientId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/things/GetAllGroups', httpOptions).pipe(catchError(this.handleError));
  }


  getStudentsForGroup(token: string, ClientId: number, groupId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      GroupId: groupId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetStudentsByGroupId',
      payload, httpOptions).pipe(catchError(this.handleError));
  }


  getAllAvailableTeachers(token: string, ClientId: number, GroupId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      GroupId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetAllAvailableTeachers',
      payload, httpOptions).pipe(catchError(this.handleError));
  }

  getGroupDetails(token: string, ClientId: number, GroupId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      GroupId
    };


    return this.http.post(this.configService.resourceApiURI + '/things/GetGroupDetails', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


  openGroup(token: string, ClientId: number, CycleId: number, LevelId: number, ShortName: string, MinDate: string, MaxDate: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ClientId, LevelId, CycleId, ShortName, MinDate, MaxDate
    };

    return this.http.post(this.configService.resourceApiURI + '/things/CreateGroup', payload,
      httpOptions).pipe(catchError(this.handleError));
  }

  RemoveStudentFromGroup(authorizationHeaderValue: string, CientId: number, GroupId: number, StudentId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      CientId, GroupId, StudentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/RemoveStudentFromGroup', payload,
      httpOptions).pipe(catchError(this.handleError));

  }


  RemoveTeacherFromGroup(authorizationHeaderValue: string, ClientId: number, GroupId: number, TeacherId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, GroupId, TeacherId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/RemoveTeacherFromGroup', payload,
      httpOptions).pipe(catchError(this.handleError));

  }

  AddTeacherToGroup(authorizationHeaderValue: string, ClientId: number, GroupId: number, TeacherId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, GroupId, TeacherId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddTeacherToGroup', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


  CreateGroupPaymentRequest(authorizationHeaderValue: string, ClientId: number, GroupId: number,
    Amount: number, PaymentRequestTypeId: number, Details: string, Duedate: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, PaymentRequestTypeId, GroupId, Amount, Details, Duedate
    };

    return this.http.post(this.configService.resourceApiURI + '/financial/CreateGroupPaymentRequest ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


  CreateNewGroupActivity(authorizationHeaderValue: string, ClientId: number, GroupId: number,
    Amount: number, PaymentRequestTypeId: number, Details: string, Duedate: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: authorizationHeaderValue
      })
    };

    const payload = {
      ClientId, PaymentRequestTypeId, GroupId, Amount, Details, Duedate
    };

    return this.http.post(this.configService.resourceApiURI + '/financial/CreateGroupPaymentRequest ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


}
