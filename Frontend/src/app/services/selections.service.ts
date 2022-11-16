import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Selections } from '../models/selections';
import { PaginatedResult } from '../models/pagination';
import { addApplicantToSelection } from '../models/addApplicantToSelection';
import { EditSelection } from '../models/editSelection';

@Injectable({
  providedIn: 'root'
})
export class SelectionsService {
  selectionUrl = environment.selectionUrl;
  private url = "GetAll";
  selections: Selections[] = [];
  paginatedResult: PaginatedResult<Selections[]> = new PaginatedResult<Selections[]>();

  constructor(private http: HttpClient) { }

  public addSelection(addSelection: { name: string, startDate: Date, endDate: Date, description: string }) {
    this.http.post<Selections>('https://localhost:7156/Selection/Add', addSelection).subscribe(x=>{
      console.log(x);
    }
      
    );
  }

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

  public getSelection(id: number) {
    return this.http.get<Selections>("https://localhost:7156/Selection/Get?id=" + id);
  }

  public addApplicantToSelection(addingApplicantToSelection: addApplicantToSelection) {
    return this.http.patch<addApplicantToSelection>('https://localhost:7156/Selection/AddApplication', addingApplicantToSelection).subscribe();
  }

  public removeApplicantFromSelection(removeApplicantFromSelection: addApplicantToSelection) {
    return this.http.patch<addApplicantToSelection>('https://localhost:7156/Selection/RemoveApplication', removeApplicantFromSelection).subscribe();
  }

  public editSelection(editSelection: { SelectionId: number, Name?: string, StartDate?: Date, EndDate?: Date, Description?: string }) {
    return this.http.put<EditSelection>('https://localhost:7156/Selection/Edit', editSelection).subscribe();
  }
}
