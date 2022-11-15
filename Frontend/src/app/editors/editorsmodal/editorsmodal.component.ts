import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EditorsService } from 'src/app/services/editors.service';

@Component({
  selector: 'app-editorsmodal',
  templateUrl: './editorsmodal.component.html',
  styleUrls: ['./editorsmodal.component.css']
})
export class EditorsmodalComponent implements OnInit {

  constructor(private editorsService: EditorsService, public dialog: MatDialog, private dialogRef: MatDialogRef<EditorsmodalComponent>) { }

  ngOnInit(): void {
  }

  onSubmit(addEditor: { firstName: string, lastName: string, email: string, userName: string, password: string }) {
    this.editorsService.addEditor(addEditor);
  }

  closeDialog() {
    this.dialogRef.close()
    window.location.reload();
  }
}
