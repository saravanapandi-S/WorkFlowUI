import { TestBed } from '@angular/core/testing';

import { CntrmovementService } from './cntrmovement.service';

describe('CntrmovementService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CntrmovementService = TestBed.get(CntrmovementService);
    expect(service).toBeTruthy();
  });
});
