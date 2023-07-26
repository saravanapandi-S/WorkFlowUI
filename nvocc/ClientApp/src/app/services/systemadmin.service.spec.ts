import { TestBed } from '@angular/core/testing';

import { SystemadminService } from './systemadmin.service';

describe('SystemadminService', () => {
  let service: SystemadminService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SystemadminService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
