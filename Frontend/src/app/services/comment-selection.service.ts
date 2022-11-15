import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SelectionComment } from '../models/selectionComment';

@Injectable({
  providedIn: 'root'
})
export class CommentSelectionService {

  constructor(private http: HttpClient) { }

  public getCommentSelection(id: number) {
    return this.http.get<Selection>('https://localhost:7156/Selection/GetById' + id);
  }

  public addComment(comments: SelectionComment) {
    console.log(comments);
    return this.http.post<SelectionComment>('https://localhost:7156/Comment/AddSelectionComment', comments).subscribe();
  }

}
