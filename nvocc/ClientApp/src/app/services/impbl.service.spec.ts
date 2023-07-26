import { TestBed } from '@angular/core/testing';

import { ImpblService } from './impbl.service';

describe('ImpblService', () => {
  let service: ImpblService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImpblService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
