/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InstrutorService } from './InstrutorService.service';

describe('Service: InstrutorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InstrutorService]
    });
  });

  it('should ...', inject([InstrutorService], (service: InstrutorService) => {
    expect(service).toBeTruthy();
  }));
});
