/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PessoaServiceService } from './PessoaService.service';

describe('Service: PessoaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PessoaServiceService]
    });
  });

  it('should ...', inject([PessoaServiceService], (service: PessoaServiceService) => {
    expect(service).toBeTruthy();
  }));
});
