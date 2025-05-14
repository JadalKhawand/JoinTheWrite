import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ViewWritingsComponent } from './pages/view-writings/view-writings.component';

export const routes: Routes = [
  { path: '', component: HomeComponent},
  {path: 'view-writings', component: ViewWritingsComponent}
];
