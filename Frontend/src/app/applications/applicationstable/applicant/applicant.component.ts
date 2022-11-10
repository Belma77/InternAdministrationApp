import { Component, OnInit, Input } from '@angular/core';
import { ApplicantsService } from 'src/app/services/applicants.service';
import { Application } from 'src/app/models/application';
import { Applicants } from 'src/app/models/applicants';

@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css']
})
export class ApplicantComponent implements OnInit {
  @Input() applicant: Applicants;
  addComment: boolean = true;
  visible: boolean = false;

  constructor(private applicantService: ApplicantsService) { }

  ngOnInit(): void {
    console.log(this.applicant);
  }

  openCommentSection() {
    this.addComment = !this.visible;
    this.visible = !this.visible;
  }

}
