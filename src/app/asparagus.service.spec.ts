import { TestBed } from '@angular/core/testing';

import { AsparagusService } from './asparagus.service';

describe('AsparagusService', () => {
  let service: AsparagusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AsparagusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
