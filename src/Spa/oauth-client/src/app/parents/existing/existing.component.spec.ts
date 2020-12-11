import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthService } from '../../core/authentication/auth.service';
import { MockAuthService } from '../../shared/mocks/mock-auth.service';
import { ParentsService } from '../parents.service';

import { ExistingParentComponent } from './existing.component';

describe('IndexComponent', () => {
  let component: ExistingParentComponent;
  let fixture: ComponentFixture<ExistingParentComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ExistingParentComponent ],
      imports: [NgxSpinnerModule],
      providers: [
        {provide: AuthService, useClass: MockAuthService},
        // {provide: GroupsService, useClass: MockTopSecretService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistingParentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
