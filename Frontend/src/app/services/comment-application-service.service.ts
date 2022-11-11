import { HttpClient, HttpParams } from '@angular/common/http';
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
    let queryParams = new HttpParams();
    queryParams = queryParams.append("id",1);
    queryParams = queryParams.append("comments","novi");
    return this.http.patch('https://localhost:7156/Application/AddComment', {params:queryParams}).subscribe(x=>{
      console.log(x);
    }

    );
  }

}
