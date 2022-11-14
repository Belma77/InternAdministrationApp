import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthguardGuard implements CanActivate {

  constructor(private authentication: AuthService, private route: Router) { }

  canActivate() {
    if (this.authentication.isLogged()) {
      return true;
    } else {
      this.route.navigate(['/login'])
      return false;
    }
  }
}
