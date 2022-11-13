import { outputAst } from '@angular/compiler';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { addApplicantToSelection } from 'src/app/models/addApplicantToSelection';
import { Applicants } from 'src/app/models/applicants';
import { Pagination } from 'src/app/models/pagination';
import { Selections } from 'src/app/models/selections';
import { SelectionsService } from 'src/app/services/selections.service';

@Component({
  selector: 'app-selectioninformation',
  templateUrl: './selectioninformation.component.html',
  styleUrls: ['./selectioninformation.component.css']
})
export class SelectioninformationComponent implements OnInit {
  @Output() loadApplicants: EventEmitter<any> = new EventEmitter();
  @Output() newSearch = new EventEmitter<string>();
  @Output() applicantId = new EventEmitter<number>();
  @Input() selection: Selections;
  @Input() applicants: Applicants[];
  @Input() pagination: Pagination;
  addComment: boolean = true;
  visible: boolean = false;
  PageNumber = 1;
  PageSize = 10;
  @Input() search: string;

  constructor(private selectionsService: SelectionsService) { }

  ngOnInit(): void {

  }

  openCommentSection() {
    this.addComment = !this.visible;
    this.visible = !this.visible;
  }

  pageChangedApplicants(event: any) {
    this.PageNumber = event.page;
    this.loadApplicants.emit();
  }

  onSearchApplicants(newSearch: string) {
    this.newSearch.emit(newSearch);
  }

  newApplicantId(applicantId: number) {
    this.applicantId.emit(applicantId);
  }

  removeApplicantToSelection(currentApplicantId: number) {
    var applicationToSelection: addApplicantToSelection = new addApplicantToSelection();
    applicationToSelection.applicationId = currentApplicantId;
    applicationToSelection.selectionId = this.selection.id;
    this.selectionsService.removeApplicantFromSelection(applicationToSelection);
  }
}
