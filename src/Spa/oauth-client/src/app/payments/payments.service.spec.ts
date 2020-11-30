import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ConfigService } from '../shared/config.service';

import { PaymentsService } from './payments.service';

describe('PaymentsService', () => {
  beforeEach(() => TestBed.configureTestingModule({

    imports: [HttpClientTestingModule],
    providers: [ConfigService]
  }));

  it('should be created', () => {
    const service: PaymentsService = TestBed.get(PaymentsService);
    expect(service).toBeTruthy();
  });
});
