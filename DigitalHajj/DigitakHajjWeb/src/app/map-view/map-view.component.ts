import { Component, OnInit } from '@angular/core';
import { StatusReportService } from '../status-report.service';
import { log } from 'util';
import { Observable, interval } from '../../../node_modules/rxjs';
import { Router } from '../../../node_modules/@angular/router';
declare var google: any;
@Component({
  selector: 'app-map-view',
  templateUrl: './map-view.component.html',
  styleUrls: ['./map-view.component.css']
})
export class MapViewComponent implements OnInit {



  constructor(private statusReportService: StatusReportService,private router: Router) { }

  options: any;

  overlays: any[];

  ngOnInit() {
    this.options = {
      center: { lat: 23.8160743, lng: 44.8472384 },
      zoom: 5.5
    };
    this.overlays = [];
    this.loadAirportStatus();
    interval(10000) //emit every 1000ms = 1 second
      .subscribe(t => {
        this.loadAirportStatus();
      });

  }
  loadAirportStatus() {
    this.statusReportService.getAirPortStatus().subscribe(
      res => {
        this.overlays.splice(0, this.overlays.length);
        res.forEach(element => {

          this.overlays.push(
            new google.maps.Circle({ airport : element.airport_id , center: { lat: parseFloat(element.lat), lng: parseFloat(element.lng) }, fillColor: '#ff76D2', fillOpacity: 0.535, strokeWeight: 1, radius: 1500 * element.total })
          );
        });

      }
    );
  }
  handleOverlayClick(event){
    
    this.router.navigateByUrl('/airport/'+event.overlay.airport);
  }
}
