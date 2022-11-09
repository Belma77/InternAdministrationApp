import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../models/application';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  constructor(private http: HttpClient) { }

  public storeApplication(postData: { firstName: string, lastName: string, email: string, educationLevel: string, coverLetter: string, cv: string }) {
    this.http.post<Application>('https://localhost:7156/Application', postData).subscribe();
  }
}
