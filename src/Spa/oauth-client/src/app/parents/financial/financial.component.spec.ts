import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthService } from '../../core/authentication/auth.service';
import { MockAuthService } from '../../shared/mocks/mock-auth.service';
import { ParentsService } from '../parents.service';

import { FinancialComponent } from './financial.component';

describe('DetailsComponent', () => {
  let component: FinancialComponent;
  let fixture: ComponentFixture<FinancialComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ FinancialComponent ],
      imports: [NgxSpinnerModule],
      providers: [
        {provide: AuthService, useClass: MockAuthService},
        // {provide: GroupsService, useClass: MockTopSecretService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinancialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
