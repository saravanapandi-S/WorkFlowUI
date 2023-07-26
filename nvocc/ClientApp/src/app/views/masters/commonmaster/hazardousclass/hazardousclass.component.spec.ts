import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HazardousclassComponent } from './hazardousclass.component';

describe('HazardousclassComponent', () => {
  let component: HazardousclassComponent;
  let fixture: ComponentFixture<HazardousclassComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HazardousclassComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HazardousclassComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
