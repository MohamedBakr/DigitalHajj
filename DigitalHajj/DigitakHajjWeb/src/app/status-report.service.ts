import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { airportstatus } from 'src/app/airportstatus.model';
import { Observable } from '../../node_modules/rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatusReportService {

  constructor(private httpClient : HttpClient) { }

  getAirPortStatus () : Observable<airportstatus[]>{
    return this.httpClient.get<airportstatus[]>('DigitalHaj/GetAirportStatus');
  }
  getAirPortDetails(airport:string) {
    return this.httpClient.get<airportstatus[]>('DigitalHaj/GetAirportStatus/'+airport);
  }
}
