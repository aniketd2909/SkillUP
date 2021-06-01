import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExperienceFeedComponent } from './experience-feed.component';

describe('ExperienceFeedComponent', () => {
  let component: ExperienceFeedComponent;
  let fixture: ComponentFixture<ExperienceFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExperienceFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExperienceFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
