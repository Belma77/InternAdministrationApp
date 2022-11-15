import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationComment } from '../models/applicationComment.model';
import { SelectionComment } from '../models/selectionComment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  public addCommentApplication(comments: ApplicationComment) {
    return this.http.post<ApplicationComment>('https://localhost:7156/Comment/AddAppComment', comments).subscribe();
  }

  public addCommentSelection(comments: SelectionComment) {
    return this.http.post<SelectionComment>('https://localhost:7156/Comment/AddSelectionComment', comments).subscribe();
  }
}
