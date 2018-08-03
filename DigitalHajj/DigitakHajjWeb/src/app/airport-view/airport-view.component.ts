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
  data : any;
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.airport = params['airport'];
      this.statusReportService.getAirPortDetails(this.airport).subscribe(
        res=>{
          this.data = res;
        }
      );
    });
    
  }

}
