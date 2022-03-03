/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InscricoesCardComponent } from './InscricoesCard.component';

describe('InscricoesCardComponent', () => {
  let component: InscricoesCardComponent;
  let fixture: ComponentFixture<InscricoesCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InscricoesCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InscricoesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
