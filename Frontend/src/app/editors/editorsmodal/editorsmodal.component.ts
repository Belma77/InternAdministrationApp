import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditorsService } from 'src/app/services/editors.service';
import { EditorsformComponent } from '../editorsform/editorsform.component';

@Component({
  selector: 'app-editorsmodal',
  templateUrl: './editorsmodal.component.html',
  styleUrls: ['./editorsmodal.component.css']
})
export class EditorsmodalComponent implements OnInit {

  constructor(private editorsService: EditorsService, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  onSubmit(addEditor: { firstName: string, lastName: string, email: string, userName: string, password: string }) {
    console.log(addEditor);
    this.editorsService.addEditor(addEditor);
  }
}
