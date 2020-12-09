import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ConfigService } from '../shared/config.service';

import { ParentsService } from './parents.service';

describe('TopSecretService', () => {
  beforeEach(() => TestBed.configureTestingModule({

    imports: [HttpClientTestingModule],
    providers: [ConfigService]
  }));

  it('should be created', () => {
    const service: ParentsService = TestBed.get(ParentsService);
    expect(service).toBeTruthy();
  });
});
