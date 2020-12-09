import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ConfigService } from '../shared/config.service';

import { TeachersService } from './teachers.service';

describe('TopSecretService', () => {
  beforeEach(() => TestBed.configureTestingModule({

    imports: [HttpClientTestingModule],
    providers: [ConfigService]
  }));

  it('should be created', () => {
    const service: TeachersService = TestBed.get(TeachersService);
    expect(service).toBeTruthy();
  });
});
