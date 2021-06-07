import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPractisesComponent } from './list-practises.component';

describe('ListPractisesComponent', () => {
  let component: ListPractisesComponent;
  let fixture: ComponentFixture<ListPractisesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPractisesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPractisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
