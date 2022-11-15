import { Component, OnInit } from '@angular/core';
import { Selections } from 'src/app/models/selections';
import { Pagination } from 'src/app/models/pagination';
import { SelectionsService } from 'src/app/services/selections.service';
import { Applicants } from 'src/app/models/applicants';
import { MatDialog } from '@angular/material/dialog';
import { AddselectionComponent } from './addselection/addselection.component';
import { Router } from '@angular/router';


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
  id: number;

  formModal: any;

  constructor(private selectionsService: SelectionsService,
    public dialog: MatDialog,
    private router: Router) { }

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

  openDialog(): void {
    this.dialog.open(AddselectionComponent, {
      width: '30%',
      data: { selections: this.selections },
    });
  }

  selectRow(id) {
    this.router.navigate(["selections/" + id]);
    this.rowSelected = true;
  }
}
