import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Editors } from '../models/editors';

@Injectable({
  providedIn: 'root'
})
export class EditorsService {
  editors: Editors[] = [];

  constructor(private http: HttpClient) { }

  public getEditors() {
    return this.http.get<Editors[]>('https://localhost:7156/Users/GetAll');
  }
}
