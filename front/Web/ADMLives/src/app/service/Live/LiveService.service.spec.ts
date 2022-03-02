/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LiveService } from './LiveService.service';

describe('Service: LiveService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiveService]
    });
  });

  it('should ...', inject([LiveService], (service: LiveService) => {
    expect(service).toBeTruthy();
  }));
});
