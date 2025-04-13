import { Component } from '@angular/core';
import { FeatureCardComponent } from "../../components/feature-card/feature-card.component";
import { NavbarComponent } from "../../components/navbar/navbar.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FeatureCardComponent, NavbarComponent],
  templateUrl: './home.component.html',
  styles: ``
})
export class HomeComponent {

}
