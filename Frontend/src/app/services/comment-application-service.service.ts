import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../models/application';

@Injectable({
  providedIn: 'root'
})
export class CommentApplicationServiceService {

  constructor(private http: HttpClient) { }

  public addCommentApplication(id: number) {
    this.http.get<Application>('https://localhost:7156/Application/' + id);
  }
}
