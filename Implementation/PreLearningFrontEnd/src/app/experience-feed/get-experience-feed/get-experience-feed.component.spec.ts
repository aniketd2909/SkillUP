import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { from } from 'rxjs';
import { ApiService } from 'src/services/api.service';

import { GetExperienceFeedComponent } from './get-experience-feed.component';

  fdescribe('GetExperienceFeedComponent', () => {
  let component: GetExperienceFeedComponent;
  let fixture: ComponentFixture<GetExperienceFeedComponent>;
  let apiService: ApiService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetExperienceFeedComponent ],
      imports: [FormsModule, HttpClientModule, RouterTestingModule,ReactiveFormsModule] ,
      providers: [ApiService] 
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetExperienceFeedComponent);
    component = fixture.componentInstance;
    apiService = TestBed.inject(ApiService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get comments in experience feed ', () => {
    const feedsList:any = [     
      {       
        postedAt: "12-09-2020",
        comment: "It was great" 
      }
    ];
    spyOn(apiService, 'get').and.callFake(() => {
      return from ([feedsList]);
    });
    component.ngOnInit();
    expect(component.feeds).toEqual(feedsList);
  }); 

  it('should get comment along with email id from experience feed ', () => {
    const feedsList:any = [     
      {     
        email: "abc@gmail.com",  
        postedAt: "12-09-2020",
        comment: "It was great" 
      }
    ];
    spyOn(apiService, 'get').and.callFake(() => {
      return from ([feedsList]);
    });
    component.ngOnInit();
    expect(component.feeds).toEqual(feedsList);
  }); 

});
