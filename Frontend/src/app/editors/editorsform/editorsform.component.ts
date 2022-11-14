import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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


  constructor(private editorsService: EditorsService, public dialog: MatDialog) { }

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
      width: '30%',
      data: {},
    });
  }

}
