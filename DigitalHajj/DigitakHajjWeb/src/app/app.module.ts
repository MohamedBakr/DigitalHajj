import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapViewComponent } from './map-view/map-view.component';
import {GMapModule} from 'primeng/gmap';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppHttpInterceptor } from 'src/app/app-interceptor.service';
import { AirportViewComponent } from './airport-view/airport-view.component';


@NgModule({
  declarations: [
    AppComponent,
    MapViewComponent,
    AirportViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GMapModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppHttpInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
