import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipmentlocationsComponent } from './shipmentlocations.component';

describe('ShipmentlocationsComponent', () => {
  let component: ShipmentlocationsComponent;
  let fixture: ComponentFixture<ShipmentlocationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipmentlocationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipmentlocationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
