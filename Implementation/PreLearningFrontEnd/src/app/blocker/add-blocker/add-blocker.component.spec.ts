import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBlockerComponent } from './add-blocker.component';

describe('AddBlockerComponent', () => {
  let component: AddBlockerComponent;
  let fixture: ComponentFixture<AddBlockerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBlockerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBlockerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
