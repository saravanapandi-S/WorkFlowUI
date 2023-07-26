import { TestBed } from '@angular/core/testing';

import { ImportBOLService } from './import-bol.service';

describe('ImportBOLService', () => {
  let service: ImportBOLService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImportBOLService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
