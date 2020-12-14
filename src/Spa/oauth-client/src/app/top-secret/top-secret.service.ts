import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
// tslint:disable-next-line:quotemark
import { BaseService } from "../shared/base.service";
import { ConfigService } from '../shared/config.service';

@Injectable({
  providedIn: 'root'
})

export class TopSecretService extends BaseService {

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
  }

  fetchTopSecretData(token: string, ClientId: number) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        Authorization: token
      })
    };

    return this.http.post(this.configService.resourceApiURI + '/things/GetAllGroups', httpOptions).pipe(catchError(this.handleError));
  }
}
