import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Applicants } from '../models/applicants';

@Injectable({
  providedIn: 'root'
})
export class ApplicantsService {
  private url = "GetAll";

  constructor(private http: HttpClient) { }

  public getApplicants(): Observable<Applicants[]> {
    return this.http.get<Applicants[]>(`${environment.apiUrl}/${this.url}`);
  }
}
