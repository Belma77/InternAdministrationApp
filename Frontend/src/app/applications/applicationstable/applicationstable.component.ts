import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Applicants } from 'src/app/models/applicants';
import { Application } from 'src/app/models/application';
import { Pagination } from 'src/app/models/pagination';
import { ApplicantsService } from 'src/app/services/applicants.service';


@Component({
  selector: 'app-applicationstable',
  templateUrl: './applicationstable.component.html',
  styleUrls: ['./applicationstable.component.css']
})
export class ApplicationstableComponent implements OnInit {
  applicant: Application;
  applicants: Applicants[];
  pagination: Pagination;
  PageNumber = 1;
  PageSize = 10;
  value: string;
  education: string;
  status: string;
  search: string;
  id: number;
  rowSelected: Boolean = false;

  constructor(
    private applicantService: ApplicantsService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.loadApplicants();
  }

  loadApplicants() {
    this.applicantService.getApplicants(this.PageNumber, this.PageSize, this.value, this.education, this.status, this.search)
      .subscribe(response => {
        this.applicants = response.result;
        this.pagination = response.pagination;
      });
  }

  pageChanged(event: any) {
    this.PageNumber = event.page;
    this.loadApplicants();
  }

  onSelect(event) {
    this.value = event;
    this.loadApplicants();
  }

  onSelectEducation(event) {
    this.education = event;
    this.loadApplicants();
  }

  onSelectStatus(event) {
    this.status = event;
    console.log(this.status);
    this.loadApplicants();
  }

  onSearch() {
    this.loadApplicants();
  }

  selectRow(id) {
    this.router.navigate(["applications/" + id]);
    this.rowSelected = true;
  }
}
