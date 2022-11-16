import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectionsService } from 'src/app/services/selections.service';

@Component({
  selector: 'app-editselection',
  templateUrl: './editselection.component.html',
  styleUrls: ['./editselection.component.css']
})
export class EditselectionComponent implements OnInit {

  constructor(private selectionService: SelectionsService,
    @Inject(MAT_DIALOG_DATA) public data: any, public dialog: MatDialog, private dialogRef: MatDialogRef<EditselectionComponent>) { }

  ngOnInit(): void {
  }

  onSubmit(editSelection: { SelectionId: number, Name?: string, StartDate?: Date, EndDate?: Date, Description?: string }) {
    editSelection.SelectionId = this.data.selections.id;
    console.log(editSelection);

    this.selectionService.editSelection(editSelection);
  }

  closeDialog() {
    this.dialogRef.close()
    window.location.reload();
  }
}
