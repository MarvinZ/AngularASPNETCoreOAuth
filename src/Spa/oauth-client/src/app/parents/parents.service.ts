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

  GetAllParents(token: string, ClientId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetAllParents', httpOptions).pipe(catchError(this.handleError));
  }


  getParentDetails(token: string, ClientId: number, ParentId: number) {
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

  addParent(token: string, ClientId: number, Name: string, Lastname1: string, Lastname2: string,
    Genre: string, Birthday: string, Email: string, Phone: string, StudentId: number, Cedula: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ClientId, Name, Lastname1, Lastname2, Birthday, Email, Phone, StudentId, Genre, Cedula
    };

    return this.http.post(this.configService.resourceApiURI + '/people/AddParent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }

  addExistingParent(token: string, ClientId: number, ParentId: number, StudentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ParentId, StudentId, ClientId
    };

    return this.http.post(this.configService.resourceApiURI + '/people/addExistingParent ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }



  GetNameFromCedula(token: string, ClientId: number, Cedula: string) {

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

  GetExistingNameFromCedula(token: string, ClientId: number, Cedula: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      ClientId, Cedula: +Cedula
    };

    return this.http.post(this.configService.resourceApiURI + '/people/GetExistingNameFromCedula ', payload,
      httpOptions).pipe(catchError(this.handleError));
  }


  GetAllFinancialsForParent(token: string, clientId: number, ParentId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      clientId, ParentId
    };
    return this.http.post(this.configService.resourceApiURI + '/financial/GetAllFinancialsForParent',
      payload, httpOptions).pipe(catchError(this.handleError));
  }


  Pay(token: string, clientId: number, ParentId: number, PaymentRequestId: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: token
      })
    };

    const payload = {
      clientId, ParentId, PaymentRequestId
    };
    return this.http.post(this.configService.resourceApiURI + '/financial/Pay',
      payload, httpOptions).pipe(catchError(this.handleError));
  }



}
