import { Component, OnInit } from '@angular/core';
import { Applicants } from 'src/app/models/applicants';
import { Pagination } from 'src/app/models/pagination';
import { ApplicantsService } from 'src/app/services/applicants.service';

@Component({
  selector: 'app-applicationstable',
  templateUrl: './applicationstable.component.html',
  styleUrls: ['./applicationstable.component.css']
})
export class ApplicationstableComponent implements OnInit {
  // applicants: Applicants[] = [];
  applicants: Applicants[];
  pagination: Pagination;
  PageNumber = 1;
  PageSize = 10;

  constructor(private applicantService: ApplicantsService) {

  }

  // ngOnInit(): void {
  //   this.applicantService.getApplicants()).subscribe((result: Applicants[]) => (this.applicants = result));
  // }

  ngOnInit(): void {
    this.loadApplicants();
  }

  loadApplicants() {
    this.applicantService.getApplicants(this.PageNumber, this.PageSize).subscribe(response => {
      this.applicants = response.result;
      this.pagination = response.pagination;
    });
  }

  pageChanged(event: any) {
    this.PageNumber = event.page;
    this.loadApplicants();
  }


}
