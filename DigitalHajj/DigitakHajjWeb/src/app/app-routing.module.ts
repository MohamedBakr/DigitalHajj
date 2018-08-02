import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MapViewComponent } from './map-view/map-view.component';
import { AirportViewComponent } from './airport-view/airport-view.component';

const routes: Routes = [
  {path: '', component: MapViewComponent},
  {path: 'airport/:airport', component: AirportViewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
