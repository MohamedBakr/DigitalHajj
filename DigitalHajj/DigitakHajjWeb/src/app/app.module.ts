import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapViewComponent } from './map-view/map-view.component';
import {GMapModule} from 'primeng/gmap';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppHttpInterceptor } from 'src/app/app-interceptor.service';
import { AirportViewComponent } from './airport-view/airport-view.component';
import { CameraViewComponent } from './camera-view/camera-view.component';
import { WebCamModule } from 'ack-angular-webcam';
import {ChartModule} from 'primeng/chart';


@NgModule({
  declarations: [
    AppComponent,
    MapViewComponent,
    AirportViewComponent,
    CameraViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GMapModule,
    HttpClientModule,
    WebCamModule,
    ChartModule
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
