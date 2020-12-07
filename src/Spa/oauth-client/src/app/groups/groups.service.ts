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

  getAllActiveGroups(token: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/things/GetAllGroups', httpOptions).pipe(catchError(this.handleError));
  }


  getStudentsForGroup(token: string, groupId: number) {

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



  getGroupDetails(token: string, GroupId: number) {
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


  openGroup(token: string, CycleId: number, LevelId: number, ShortName: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      LevelId, CycleId, ShortName
    };


    return this.http.post(this.configService.resourceApiURI + '/things/CreateGroup', payload,
      httpOptions).pipe(catchError(this.handleError));
  }




}
