import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BestPractisesComponent } from './best-practises.component';

describe('BestPractisesComponent', () => {
  let component: BestPractisesComponent;
  let fixture: ComponentFixture<BestPractisesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BestPractisesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BestPractisesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
