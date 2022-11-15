import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Editors } from 'src/app/models/editors';
import { EditorsService } from 'src/app/services/editors.service';
import { EditorsmodalComponent } from '../editorsmodal/editorsmodal.component';

declare var window: any;

@Component({
  selector: 'app-editorsform',
  templateUrl: './editorsform.component.html',
  styleUrls: ['./editorsform.component.css']
})
export class EditorsformComponent implements OnInit {
  editors: Editors[];

  formModal: any;

  constructor(private editorsService: EditorsService,
    private dialog: MatDialog,
    private snackbar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.loadEditors();
    this.formModal = new window.bootstrap.Modal(
      document.getElementById("exampleModal")
    );
  }

  openModal() {
    this.formModal.show();
  }

  addEditor() {
    this.formModal.hide();
  }

  loadEditors() {
    this.editorsService.getEditors().subscribe(response => {
      this.editors = response;
    });
  }

  openDialog(): void {
    this.dialog.open(EditorsmodalComponent, {
      width: "60vh",
      maxWidth: "650px",
      maxHeight: "900px",
      data: {},
    });
  }

  deleteEditor(id: string) {
    if (id == "b74ddd14-6340-4840-95c2-db12554843e5") {
      this.snackbar.open("Can't delete Admin", null, {});
      return;
    }
    this.editorsService.deleteEditor(id);
  }
}
