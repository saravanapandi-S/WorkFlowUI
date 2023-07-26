import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentlocationsviewComponent } from './shipmentlocationsview.component';

describe('ShipmentlocationsviewComponent', () => {
  let component: ShipmentlocationsviewComponent;
  let fixture: ComponentFixture<ShipmentlocationsviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipmentlocationsviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipmentlocationsviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
