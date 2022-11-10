import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Applicants } from '../models/applicants';
import { Application } from '../models/application';
import { PaginatedResult } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ApplicantsService {
  baseUrl = environment.apiUrl;
  private url = "GetAll";
  applicants: Applicants[] = [];
  paginatedResult: PaginatedResult<Applicants[]> = new PaginatedResult<Applicants[]>();

  constructor(private http: HttpClient) { }

  public getApplicants(page?: number, ItemsPerPage?: number, sort?: string, educationSort?: string, status?: string, search?: string) {
    let params = new HttpParams();
    if (page != null && ItemsPerPage !== null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', ItemsPerPage.toString());
    }
    if (sort) {
      params = params.append('OrderBy', sort);
    }
    if (educationSort) {
      params = params.append('filter.EducationLevel', educationSort);
    }
    if (status) {
      params = params.append('filter.Status', status);
    }
    if (search) {
      params = params.append('filter.Name', search);
    }
    return this.http.get<Applicants[]>(this.baseUrl + '/GetAll', { observe: 'response', params }).pipe(
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
