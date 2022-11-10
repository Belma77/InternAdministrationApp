import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Selections } from '../models/selections';
import { PaginatedResult } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class SelectionsService {
  selectionUrl = environment.selectionUrl;
  private url = "GetAll";
  selections: Selections[] = [];
  paginatedResult: PaginatedResult<Selections[]> = new PaginatedResult<Selections[]>();

  constructor(private http: HttpClient) { }

  public getSelections(page?: number, ItemsPerPage?: number, selectionName?: string, searchName?: string) {
    let params = new HttpParams();
    if (page != null && ItemsPerPage !== null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', ItemsPerPage.toString());
    }
    if (selectionName) {
      params = params.append('OrderBy', selectionName);
    }
    if (searchName) {
      params = params.append('filterSelections.Name', searchName);
    }
    return this.http.get<Selections[]>(this.selectionUrl + '/GetAll', { observe: 'response', params }).pipe(
      map(response => {
        this.paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return this.paginatedResult;
      })
    )
  }
}
