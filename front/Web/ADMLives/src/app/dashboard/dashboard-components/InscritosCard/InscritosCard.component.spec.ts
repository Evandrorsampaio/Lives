/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InscritosCardComponent } from './InscritosCard.component';

describe('InscritosCardComponent', () => {
  let component: InscritosCardComponent;
  let fixture: ComponentFixture<InscritosCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InscritosCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InscritosCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
