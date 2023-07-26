import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UomconversionsviewComponent } from './uomconversionsview.component';

describe('UomconversionsviewComponent', () => {
  let component: UomconversionsviewComponent;
  let fixture: ComponentFixture<UomconversionsviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UomconversionsviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UomconversionsviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
