import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../models/application';
import { ApplicationComment } from '../models/applicationComment.model';

@Injectable({
  providedIn: 'root'
})
export class CommentApplicationServiceService {

  constructor(private http: HttpClient) { }

  public addCommentApplication(id: number) {
    return this.http.get<Application>('https://localhost:7156/Application/' + id);
  }

  public addComment(comments: ApplicationComment) {
    console.log(comments);
    return this.http.patch<ApplicationComment>('https://localhost:7156/Application/AddComment', comments).subscribe();
  }

}
