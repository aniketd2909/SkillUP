import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBlockerComponent } from './list-blocker.component';

describe('ListBlockerComponent', () => {
  let component: ListBlockerComponent;
  let fixture: ComponentFixture<ListBlockerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListBlockerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBlockerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
