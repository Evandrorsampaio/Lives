/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LivesCardComponent } from './LivesCard.component';

describe('LivesCardComponent', () => {
  let component: LivesCardComponent;
  let fixture: ComponentFixture<LivesCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LivesCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LivesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
