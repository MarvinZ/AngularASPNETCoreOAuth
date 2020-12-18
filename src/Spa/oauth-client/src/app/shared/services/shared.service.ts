import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../base.service';
import { ConfigService } from '../config.service';

@Injectable({
  providedIn: 'root'
})

export class SharedService extends BaseService {


  public theCatalog: any;

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  getCatalog() {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'PENDING'
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/things/GetCatalog', httpOptions).pipe(catchError(this.handleError));
  }




}
