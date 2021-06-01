import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateExperienceFeedComponent } from './update-experience-feed.component';

describe('UpdateExperienceFeedComponent', () => {
  let component: UpdateExperienceFeedComponent;
  let fixture: ComponentFixture<UpdateExperienceFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateExperienceFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateExperienceFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
