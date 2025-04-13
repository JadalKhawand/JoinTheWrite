import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewWritingsComponent } from './view-writings.component';

describe('ViewWritingsComponent', () => {
  let component: ViewWritingsComponent;
  let fixture: ComponentFixture<ViewWritingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewWritingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewWritingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
