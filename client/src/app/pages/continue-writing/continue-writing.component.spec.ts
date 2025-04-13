import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContinueWritingComponent } from './continue-writing.component';

describe('ContinueWritingComponent', () => {
  let component: ContinueWritingComponent;
  let fixture: ComponentFixture<ContinueWritingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContinueWritingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContinueWritingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
