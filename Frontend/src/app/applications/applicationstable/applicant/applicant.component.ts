import { Component, OnInit } from '@angular/core';
import { ApplicantsService } from 'src/app/services/applicants.service';
import { Applicants } from 'src/app/models/applicants';
import { ApplicationComment } from 'src/app/models/applicationComment.model';
import { AppUpdateStatus } from 'src/app/models/appUpdateStatus';
import { ActivatedRoute, Params } from '@angular/router';
import { CommentService } from 'src/app/services/comment.service';


@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css']
})
export class ApplicantComponent implements OnInit {
  applicants: Applicants;
  addComment: boolean = true;
  visible: boolean = false;
  status: string;
  id: number;


  constructor(private applicantService: ApplicantsService,
    private commentService: CommentService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    })
    this.applicantService.getApplicant(this.id).subscribe(response => {
      this.applicants = response;
    })
  }

  openCommentSection() {
    this.addComment = !this.visible;
    this.visible = !this.visible;
  }

  onComment(commentBody: string) {
    var comment: ApplicationComment = new ApplicationComment();
    comment.Comment = commentBody;
    comment.ApplicationId = this.applicants.id;
    this.commentService.addCommentApplication(comment);
    window.location.reload();
  }

  onUpdateStatus(newStatus: string) {
    var status: AppUpdateStatus = new AppUpdateStatus();
    status.ApplicationId = this.applicants.id;
    status.Status = newStatus;
    this.applicantService.changeStatus(status);
    window.location.reload();
  }
}
