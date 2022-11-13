import { Component, OnInit } from '@angular/core';
import { Editors } from 'src/app/models/editors';
import { EditorsService } from 'src/app/services/editors.service';

declare var window: any;

@Component({
  selector: 'app-editorsform',
  templateUrl: './editorsform.component.html',
  styleUrls: ['./editorsform.component.css']
})
export class EditorsformComponent implements OnInit {
  editors: Editors[];

  formModal: any;


  constructor(private editorsService: EditorsService) { }

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

}
