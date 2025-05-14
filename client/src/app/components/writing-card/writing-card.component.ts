import { Component, Input, ChangeDetectionStrategy } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Writing {
  title: string;
  excerpt: string;
  // Add other relevant properties
}

@Component({
  selector: 'app-writing-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './writing-card.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class WritingCardComponent {
  @Input() writing!: Writing; 
}