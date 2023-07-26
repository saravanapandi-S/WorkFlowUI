import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HazardousclassviewComponent } from './hazardousclassview.component';

describe('HazardousclassviewComponent', () => {
  let component: HazardousclassviewComponent;
  let fixture: ComponentFixture<HazardousclassviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HazardousclassviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HazardousclassviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
