import { TestBed } from '@angular/core/testing';

import { MovementUploadConfigService } from './movement-upload-config.service';

describe('MovementUploadConfigService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MovementUploadConfigService = TestBed.get(MovementUploadConfigService);
    expect(service).toBeTruthy();
  });
});
