import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteExperienceFeedComponent } from './delete-experience-feed.component';

describe('DeleteExperienceFeedComponent', () => {
  let component: DeleteExperienceFeedComponent;
  let fixture: ComponentFixture<DeleteExperienceFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteExperienceFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteExperienceFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
