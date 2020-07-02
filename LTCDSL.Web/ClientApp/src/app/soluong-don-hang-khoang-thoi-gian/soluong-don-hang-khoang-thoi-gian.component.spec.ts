import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SoluongDonHangKhoangThoiGianComponent } from './soluong-don-hang-khoang-thoi-gian.component';

describe('SoluongDonHangKhoangThoiGianComponent', () => {
  let component: SoluongDonHangKhoangThoiGianComponent;
  let fixture: ComponentFixture<SoluongDonHangKhoangThoiGianComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SoluongDonHangKhoangThoiGianComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SoluongDonHangKhoangThoiGianComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
