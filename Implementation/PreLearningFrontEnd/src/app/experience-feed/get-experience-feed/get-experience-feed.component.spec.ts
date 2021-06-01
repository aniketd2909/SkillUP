import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetExperienceFeedComponent } from './get-experience-feed.component';

describe('GetExperienceFeedComponent', () => {
  let component: GetExperienceFeedComponent;
  let fixture: ComponentFixture<GetExperienceFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetExperienceFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetExperienceFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
