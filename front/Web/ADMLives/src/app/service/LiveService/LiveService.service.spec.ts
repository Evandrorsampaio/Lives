/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LiveServiceService } from './LiveService.service';

describe('Service: LiveService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiveServiceService]
    });
  });

  it('should ...', inject([LiveServiceService], (service: LiveServiceService) => {
    expect(service).toBeTruthy();
  }));
});
