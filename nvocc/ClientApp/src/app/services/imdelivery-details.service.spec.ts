import { TestBed } from '@angular/core/testing';

import { ImdeliveryDetailsService } from './imdelivery-details.service';

describe('ImdeliveryDetailsService', () => {
  let service: ImdeliveryDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImdeliveryDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
