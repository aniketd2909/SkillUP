import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayProblemStatementsComponent } from './display-problem-statements.component';

describe('DisplayProblemStatementsComponent', () => {
  let component: DisplayProblemStatementsComponent;
  let fixture: ComponentFixture<DisplayProblemStatementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayProblemStatementsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayProblemStatementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
