/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InscricaoService } from './InscricaoService.service';

describe('Service: InscricaoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InscricaoService]
    });
  });

  it('should ...', inject([InscricaoService], (service: InscricaoService) => {
    expect(service).toBeTruthy();
  }));
});
