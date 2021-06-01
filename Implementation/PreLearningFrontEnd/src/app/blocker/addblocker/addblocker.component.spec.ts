import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddblockerComponent } from './addblocker.component';

describe('AddblockerComponent', () => {
  let component: AddblockerComponent;
  let fixture: ComponentFixture<AddblockerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddblockerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddblockerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
