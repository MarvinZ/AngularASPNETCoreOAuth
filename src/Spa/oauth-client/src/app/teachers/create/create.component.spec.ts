import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AuthService } from '../../core/authentication/auth.service';
import { MockAuthService } from '../../shared/mocks/mock-auth.service';
import { TeachersService } from '../teachers.service';

import { CreateComponent } from './create.component';

describe('IndexComponent', () => {
  let component: CreateComponent;
  let fixture: ComponentFixture<CreateComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateComponent ],
      imports: [NgxSpinnerModule],
      providers: [
        {provide: AuthService, useClass: MockAuthService},
        // {provide: GroupsService, useClass: MockTopSecretService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
