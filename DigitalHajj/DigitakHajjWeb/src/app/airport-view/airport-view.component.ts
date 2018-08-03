import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '../../../node_modules/@angular/router';
import { StatusReportService } from '../status-report.service';

@Component({
  selector: 'app-airport-view',
  templateUrl: './airport-view.component.html',
  styleUrls: ['./airport-view.component.css']
})
export class AirportViewComponent implements OnInit {
  airport: string;
  constructor(private statusReportService: StatusReportService, private router: Router, private route: ActivatedRoute) { }
  data: any;
  data_stats: any;
  data_stats_jawazat:any;
  data_stats_custom :any;
  options : any;
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.airport = params['airport'];
      this.statusReportService.getAirPortDetails(this.airport).subscribe(
        res => {
          this.data = res;
        }
      );

      this.options = {
        title: {
            display: true,
            text: 'Waiting Number',
            fontSize: 16
        },
        legend: {
            position: 'bottom'
        }
    };

      this.statusReportService.getAirPortStats(this.airport).subscribe(
        res => {
          this.data_stats = {
            labels:  res.map(a =>  a.total),
            datasets: [
              {
                label: 'First Dataset',
                data: res.map(a =>  a.total)
              }
            ]
          };

        }
      );

      this.statusReportService.getHalltStats(this.airport,"1").subscribe(
        res => {
          this.data_stats_jawazat = {
            labels:  res.map(a =>  a.total),
            datasets: [
              {
                label: 'First Dataset',
                data: res.map(a =>  a.total)
              }
            ]
          };

        }
      );

      this.statusReportService.getHalltStats(this.airport,"1").subscribe(
        res => {
          this.data_stats_jawazat = {
            labels:  res.map(a =>  a.total),
            datasets: [
              {
                label: 'First Dataset',
                data: res.map(a =>  a.total)
              }
            ]
          };
        }
      );

      this.statusReportService.getHalltStats(this.airport,"2").subscribe(
        res => {
          this.data_stats_custom = {
            labels:  res.map(a =>  a.total),
            datasets: [
              {
                label: 'First Dataset',
                data: res.map(a =>  a.total)
              }
            ]
          };
        }
      );

    });

  }

}
