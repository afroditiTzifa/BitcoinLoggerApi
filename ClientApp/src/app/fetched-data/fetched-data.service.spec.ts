import { TestBed } from '@angular/core/testing';

import { FetchedDataService } from './fetched-data.service';

describe('FetchedDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FetchedDataService = TestBed.get(FetchedDataService);
    expect(service).toBeTruthy();
  });
});
