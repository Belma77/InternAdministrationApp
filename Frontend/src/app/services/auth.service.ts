import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public login(login: { username: string, password: string }) {
    return this.http.post<Login>('https://localhost:7156/api/Auth/login', login);
  }

  public isLogged() {
    return localStorage.getItem('token') != null;
  }

  isAdmin() {
    var token = localStorage.getItem('token') || '';
    var recievedToken = token.split('.')[1];
    var atobData = atob(recievedToken);
    var data = JSON.parse(atobData);
    const role = data['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    if (role == 'Admin') {
      return true;
    } else {
      return false;
    }
  }
}
