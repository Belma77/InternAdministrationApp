import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApplicantsService } from 'src/app/services/applicants.service';
import { Application } from 'src/app/models/application';
import { Applicants } from 'src/app/models/applicants';
import { CommentApplicationServiceService } from 'src/app/services/comment-application-service.service';
import { ApplicationComment } from 'src/app/models/applicationComment.model';


@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css']
})
export class ApplicantComponent implements OnInit {
  @Output("onSelectApplicant") onSelectApplicant: EventEmitter<any> = new EventEmitter();
  @Input() applicants: Applicants;
  addComment: boolean = true;
  visible: boolean = false;
  newStatus: string;


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
    comment.comments = commentBody;
    comment.id = this.applicants.id;
    console.log(comment);
    this.service.addComment(comment);
    this.onSelectApplicant.emit();
  }

  onUpdateStatus(status: string) {

  }

}
