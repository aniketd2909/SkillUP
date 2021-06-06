import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayMcqComponent } from './display-mcq.component';

describe('DisplayMcqComponent', () => {
  let component: DisplayMcqComponent;
  let fixture: ComponentFixture<DisplayMcqComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayMcqComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayMcqComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
