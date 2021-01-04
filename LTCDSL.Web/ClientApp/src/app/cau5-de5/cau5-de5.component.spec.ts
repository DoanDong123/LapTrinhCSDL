import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Cau5De5Component } from './cau5-de5.component';

describe('Cau5De5Component', () => {
  let component: Cau5De5Component;
  let fixture: ComponentFixture<Cau5De5Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Cau5De5Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Cau5De5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
