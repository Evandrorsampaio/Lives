/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InscritoServiceService } from './InscritoService.service';

describe('Service: InscritoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InscritoServiceService]
    });
  });

  it('should ...', inject([InscritoServiceService], (service: InscritoServiceService) => {
    expect(service).toBeTruthy();
  }));
});
