import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { SharedService } from './shared/services/shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor( private service: SharedService) {
  }

  ngOnInit() {

    this.service.getCatalog()
      .pipe(finalize(() => {


      })).subscribe(
        result => {
          this.service.theCatalog = result;
        });

  }

}
