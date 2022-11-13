import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TokenService implements HttpInterceptor {

  constructor(private inject: Injector) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = req.clone({
      setHeaders: {
        Authorization: 'bearer ' + this.getToken()
      }
    });
    return next.handle(token);
  }
  getToken() {
    return localStorage.getItem('token') || '';
  }
}


