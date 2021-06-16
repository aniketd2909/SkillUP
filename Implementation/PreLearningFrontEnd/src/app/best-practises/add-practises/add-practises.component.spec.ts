import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPractisesComponent } from './add-practises.component';

describe('AddPractisesComponent', () => {
  let component: AddPractisesComponent;
  let fixture: ComponentFixture<AddPractisesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPractisesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPractisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
