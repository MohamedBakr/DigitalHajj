import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '../environments/environment';
import { tap } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {
  constructor() {
  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const headers = req.headers;
    if (!(req.body instanceof FormData)) {
      headers.append('Content-Type', 'application/json');
      headers.append('Accept', 'application/json');
      headers.append('Cache-control', 'no-cache');
    }
    const options = { headers: headers, withCredentials: true, url: environment.ServiceUrl + req.url };
    const authReq = req.clone(options);

    return next.handle(authReq).pipe(tap(event => {

    })).pipe(catchError((err: any, caught) => {
      if (err instanceof HttpErrorResponse) {
        return Observable.throw(err);
      }
    }));
  }
}