import { TestBed } from '@angular/core/testing';

import { HandleauthErrorService } from './handleauth-error.service';

describe('HandleauthErrorService', () => {
  let service: HandleauthErrorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HandleauthErrorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
