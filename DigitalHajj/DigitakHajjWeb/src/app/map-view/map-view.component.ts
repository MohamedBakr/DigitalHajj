import { Component, OnInit } from '@angular/core';
declare var google: any;
@Component({
  selector: 'app-map-view',
  templateUrl: './map-view.component.html',
  styleUrls: ['./map-view.component.css']
})
export class MapViewComponent implements OnInit {



  constructor() { }

  options: any;

    overlays: any[];

    ngOnInit() {
        this.options = {
            center: {lat:23.8160743 , lng: 44.8472384},
            zoom: 5.5
        };
        this.overlays= [
          new google.maps.Circle({center: {lat: 21.6708338, lng: 39.1486065}, fillColor: '#ff76D2', fillOpacity: 0.535, strokeWeight: 1, radius: 150000}),
          new google.maps.Circle({center: {lat: 24.5537422, lng: 39.7128899}, fillColor: '#ff76D2', fillOpacity: 0.535, strokeWeight: 1, radius: 150000}),
        ];
    }
}
