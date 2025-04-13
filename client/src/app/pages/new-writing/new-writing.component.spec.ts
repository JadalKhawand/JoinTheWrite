import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewWritingComponent } from './new-writing.component';

describe('NewWritingComponent', () => {
  let component: NewWritingComponent;
  let fixture: ComponentFixture<NewWritingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewWritingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewWritingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
