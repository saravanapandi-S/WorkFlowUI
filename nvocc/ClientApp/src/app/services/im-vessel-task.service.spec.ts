import { TestBed } from '@angular/core/testing';

import { ImVesselTaskService } from './im-vessel-task.service';

describe('ImVesselTaskService', () => {
  let service: ImVesselTaskService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImVesselTaskService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
