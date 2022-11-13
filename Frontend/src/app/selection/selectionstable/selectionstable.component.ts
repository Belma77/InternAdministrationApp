import { Component, OnInit } from '@angular/core';
import { Selections } from 'src/app/models/selections';
import { Pagination } from 'src/app/models/pagination';
import { SelectionsService } from 'src/app/services/selections.service';
import { ApplicantsService } from 'src/app/services/applicants.service';
import { Applicants } from 'src/app/models/applicants';
import { addApplicantToSelection } from 'src/app/models/addApplicantToSelection';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddselectionComponent } from './addselection/addselection.component';

declare var window: any;

@Component({
  selector: 'app-selectionstable',
  templateUrl: './selectionstable.component.html',
  styleUrls: ['./selectionstable.component.css']
})
export class SelectionstableComponent implements OnInit {
  selection: Selections;
  selections: Selections[];
  applicants: Applicants[];
  pagination: Pagination;
  PageNumber = 1;
  PageSize = 10;
  selectionName: string;
  searchName: string;
  rowSelected: boolean = false;


  formModal: any;


  constructor(private selectionsService: SelectionsService, private applicantService: ApplicantsService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadSelections();

    this.formModal = new window.bootstrap.Modal(
      document.getElementById("exampleModal1")
    );
  }

  loadSelections() {
    this.selectionsService.getSelections(this.PageNumber, this.PageSize, this.selectionName, this.searchName).subscribe(response => {
      this.selections = response.result;
      this.pagination = response.pagination;
    });
  }

  pageChanged(event: any) {
    this.PageNumber = event.page;
    this.loadSelections();
  }

  openModal() {
    this.formModal.show();

  }

  onNameSelect(event) {
    this.selectionName = event;
    this.loadSelections();
  }

  addSelection() {
    this.formModal.hide();
  }

  onSearch() {
    this.loadSelections();
  }

  searchSelectionName() {
    this.loadSelections();
  }

  onSelectSelection(selections: Selections) {
    this.selection = selections;
    this.selectionsService.getSelection(this.selection.id).subscribe(response => {
      // this.loadApplicantsPreselection();
      this.loadApplicants("");
      this.selection = response;
      this.rowSelected = true;
    })
  }

  // loadApplicantsPreselection() {
  //   this.applicantService.getApplicantPreselection().subscribe(response => {
  //     this.applicants = response;
  //   })
  // }

  loadApplicants(newSearch: string) {
    this.applicantService.getApplicantsPreselection(newSearch).subscribe(response => {
      this.applicants = response.result;
      this.pagination = response.pagination;
    });
  }

  addApplicantToSelection(currentApplicantId: number) {
    var applicationToSelection: addApplicantToSelection = new addApplicantToSelection();
    applicationToSelection.applicationId = currentApplicantId;
    applicationToSelection.selectionId = this.selection.id;
    this.selectionsService.addApplicantToSelection(applicationToSelection);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddselectionComponent, {
      width: '50%',
      data: { selections: this.selections },
    });
  }
}
