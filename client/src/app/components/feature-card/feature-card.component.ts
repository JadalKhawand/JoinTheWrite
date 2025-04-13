import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feature-card',
  standalone: true,
  imports: [],
  templateUrl: './feature-card.component.html',
  styles: ``
})
export class FeatureCardComponent {
  @Input() icon: string = 'info';
  @Input() title: string = 'Card Title';
  @Input() route: string = '/';

  constructor(private router: Router) {}

  navigate() {
    this.router.navigate([this.route]);
  }
}
