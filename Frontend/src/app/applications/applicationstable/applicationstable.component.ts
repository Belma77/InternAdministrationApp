import { Component, OnInit } from '@angular/core';
import { Applicants } from 'src/app/models/applicants';
import { ApplicantsService } from 'src/app/services/applicants.service';

@Component({
  selector: 'app-applicationstable',
  templateUrl: './applicationstable.component.html',
  styleUrls: ['./applicationstable.component.css']
})
export class ApplicationstableComponent implements OnInit {
  applicants: Applicants[] = [];

  constructor(private applicantService: ApplicantsService) {

  }

  ngOnInit(): void {
    this.applicantService.getApplicants().subscribe((result: Applicants[]) => (this.applicants = result));
  }

}
