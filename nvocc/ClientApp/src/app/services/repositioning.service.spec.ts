import { TestBed } from '@angular/core/testing';

import { RepositioningService } from './repositioning.service';

describe('RepositioningService', () => {
  let service: RepositioningService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RepositioningService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
