import { TestBed } from '@angular/core/testing';

import { CostAccountingService } from './cost-accounting.service';

describe('CostAccountingService', () => {
  let service: CostAccountingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CostAccountingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
