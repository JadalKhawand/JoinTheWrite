import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WritingCardComponent } from './writing-card.component';

describe('WritingCardComponent', () => {
  let component: WritingCardComponent;
  let fixture: ComponentFixture<WritingCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WritingCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WritingCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
