import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Params } from '@angular/router';
import { addApplicantToSelection } from 'src/app/models/addApplicantToSelection';
import { Applicants } from 'src/app/models/applicants';
import { Pagination } from 'src/app/models/pagination';
import { SelectionComment } from 'src/app/models/selectionComment';
import { Selections } from 'src/app/models/selections';
import { ApplicantsService } from 'src/app/services/applicants.service';
import { CommentService } from 'src/app/services/comment.service';
import { SelectionsService } from 'src/app/services/selections.service';
import { EditselectionComponent } from './editselection/editselection.component';

@Component({
  selector: 'app-selectioninformation',
  templateUrl: './selectioninformation.component.html',
  styleUrls: ['./selectioninformation.component.css']
})
export class SelectioninformationComponent implements OnInit {
  @Output() loadApplicants: EventEmitter<any> = new EventEmitter();
  @Output() newSearch = new EventEmitter<string>();
  @Output() applicantId = new EventEmitter<number>();
  @Input()
  selections: Selections[];
  @Input() selection: Selections;
  @Input() applicants: Applicants[];
  @Input() pagination: Pagination;
  addComment: boolean = false;
  openApplicants: boolean = false;
  visible: boolean = false;
  PageNumber = 1;
  PageSize = 10;
  @Input() search: string;
  id: number;

  constructor(private applicantService: ApplicantsService,
    private selectionsService: SelectionsService,
    public dialog: MatDialog,
    private commentService: CommentService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    })
    this.selectionsService.getSelection(this.id).subscribe(response => {
      this.selection = response;
      this.loadApplicantsInSelection("");
    })
  }

  dateEdited() {
    if (this.selection.dateEdited == null) {
      return true;
    } else {
      return false;
    }
  }

  openApplicantsSection() {
    this.openApplicants = !this.visible;
    this.visible = !this.visible;
  }

  openCommentSection() {
    this.addComment = !this.visible;
    this.visible = !this.visible;
  }

  onSearchApplicants(newSearch: string) {
    this.loadApplicantsInSelection(newSearch);
  }

  removeApplicantToSelection(currentApplicantId: number) {
    var applicationToSelection: addApplicantToSelection = new addApplicantToSelection();
    applicationToSelection.applicationId = currentApplicantId;
    applicationToSelection.selectionId = this.id;
    this.selectionsService.removeApplicantFromSelection(applicationToSelection);
    window.location.reload();
  }

  onComment(commentBody: string) {
    var comment: SelectionComment = new SelectionComment();
    comment.comment = commentBody;
    comment.selectionId = this.id;
    this.commentService.addCommentSelection(comment);
    window.location.reload();
  }

  loadApplicantsInSelection(newSearch: string) {
    this.applicantService.getApplicantsPreselection(newSearch).subscribe(response => {
      this.applicants = response.result;
      this.pagination = response.pagination;
    });
  }

  addApplicantToSelection(currentApplicantId: number) {
    var applicationToSelection: addApplicantToSelection = new addApplicantToSelection();
    applicationToSelection.applicationId = currentApplicantId;
    applicationToSelection.selectionId = this.id;
    this.selectionsService.addApplicantToSelection(applicationToSelection);
    window.location.reload();
  }

  openDialog(): void {
    this.dialog.open(EditselectionComponent, {
      width: "60vh",
      maxWidth: "650px",
      maxHeight: "900px",
      data: { selections: this.selection },
    });
  }
}
