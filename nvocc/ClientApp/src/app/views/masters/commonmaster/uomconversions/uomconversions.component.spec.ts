import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UomconversionsComponent } from './uomconversions.component';

describe('UomconversionsComponent', () => {
  let component: UomconversionsComponent;
  let fixture: ComponentFixture<UomconversionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UomconversionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UomconversionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
