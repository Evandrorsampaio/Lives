/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InscricaoServiceService } from './InscricaoService.service';

describe('Service: InscricaoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InscricaoServiceService]
    });
  });

  it('should ...', inject([InscricaoServiceService], (service: InscricaoServiceService) => {
    expect(service).toBeTruthy();
  }));
});
