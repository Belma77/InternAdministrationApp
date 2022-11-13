import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApplicantsService } from 'src/app/services/applicants.service';
import { Application } from 'src/app/models/application';
import { Applicants } from 'src/app/models/applicants';
import { CommentApplicationServiceService } from 'src/app/services/comment-application-service.service';
import { ApplicationComment } from 'src/app/models/applicationComment.model';
import { AppUpdateStatus } from 'src/app/models/appUpdateStatus';
import { Status } from 'src/app/services/statusEnum';


@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css']
})
export class ApplicantComponent implements OnInit {
  @Input() applicants: Applicants;
  addComment: boolean = true;
  visible: boolean = false;
  status: string;


  constructor(private applicantService: ApplicantsService, private service: CommentApplicationServiceService) { }

  ngOnInit(): void {
  }

  openCommentSection() {
    this.addComment = !this.visible;
    this.visible = !this.visible;
  }

  onComment(commentBody: string) {
    var comment: ApplicationComment = new ApplicationComment();
    console.log(commentBody);
    comment.Comment = commentBody;
    comment.ApplicationId = this.applicants.id;
    console.log(comment);
    this.service.addComment(comment);
  }

  onUpdateStatus(newStatus: string) {
    console.log(newStatus);
    var status: AppUpdateStatus = new AppUpdateStatus();
    status.ApplicationId = this.applicants.id;
    status.Status = newStatus;
    console.log(newStatus);
    this.applicantService.changeStatus(status);
  }

}
