import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ConfigService } from '../shared/config.service';

import { GroupsService } from './groups.service';

describe('TopSecretService', () => {
  beforeEach(() => TestBed.configureTestingModule({

    imports: [HttpClientTestingModule],
    providers: [ConfigService]
  }));

  it('should be created', () => {
    const service: GroupsService = TestBed.get(GroupsService);
    expect(service).toBeTruthy();
  });
});
