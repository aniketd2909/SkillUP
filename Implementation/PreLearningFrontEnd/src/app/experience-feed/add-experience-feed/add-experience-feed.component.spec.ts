import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddExperienceFeedComponent } from './add-experience-feed.component';

describe('AddExperienceFeedComponent', () => {
  let component: AddExperienceFeedComponent;
  let fixture: ComponentFixture<AddExperienceFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddExperienceFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddExperienceFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
