import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormsValidationSimple1Component } from './forms-validation-simple1.component';

describe('FormsValidationSimple1Component', () => {
  let component: FormsValidationSimple1Component;
  let fixture: ComponentFixture<FormsValidationSimple1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormsValidationSimple1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormsValidationSimple1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
