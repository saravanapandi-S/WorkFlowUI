import { TestBed } from '@angular/core/testing';

import { ImArrivalNoticeService } from './im-arrival-notice.service';

describe('ImArrivalNoticeService', () => {
  let service: ImArrivalNoticeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImArrivalNoticeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
