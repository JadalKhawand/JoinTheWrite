import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WritingCardComponent } from '../../components/writing-card/writing-card.component'; // Import the new component
import { NavbarComponent } from '../../components/navbar/navbar.component';

interface Writing {
  title: string;
  excerpt: string;
  // Add other relevant properties
}

@Component({
  selector: 'app-view-writings',
  standalone: true,
  imports: [CommonModule, WritingCardComponent, NavbarComponent], // Add WritingCardComponent to imports
  templateUrl: './view-writings.component.html',
  styles: ``,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ViewWritingsComponent implements OnInit {
  writings: Writing[] = Array(12).fill(null).map((_, index) => ({
    title: `Writing ${index + 1}`,
    excerpt: 'A short preview of the writing content...',
  })); // Dummy data with title and excerpt

  constructor() {}

  ngOnInit(): void {}
}