import { TestBed } from '@angular/core/testing';

import { ChoreService } from './chore.service';

describe('ChoreService', () => {
  let service: ChoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
