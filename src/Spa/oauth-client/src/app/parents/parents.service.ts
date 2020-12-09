import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../shared/base.service';
import { ConfigService } from '../shared/config.service';

@Injectable({
  providedIn: 'root'
})

export class ParentsService extends BaseService {


  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  GetAllParents(token: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetAllParents', httpOptions).pipe(catchError(this.handleError));
  }


  getParentDetails(token: string, ParentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ParentId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetParentDetails', payload,
      httpOptions).pipe(catchError(this.handleError));
  }

  addParent(token: string, Name: string, Lastname1: string, Lastname2: string,
            Genre: string, Birthday: string, Email: string, Phone: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      Name, Lastname1, Lastname2, Birthday, Email, Phone
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddParent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }



}
