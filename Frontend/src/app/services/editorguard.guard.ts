import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class EditorguardGuard implements CanActivate {
  constructor(private authentication: AuthService, private route: Router) { }

  canActivate() {
    if (this.authentication.isAdmin()) {
      return true;
    } else {
      return false;
    }
  }

}
