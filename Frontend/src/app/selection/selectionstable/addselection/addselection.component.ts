import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { SelectionsService } from 'src/app/services/selections.service';

@Component({
  selector: 'app-addselection',
  templateUrl: './addselection.component.html',
  styleUrls: ['./addselection.component.css']
})
export class AddselectionComponent implements OnInit {

  constructor(private selectionService: SelectionsService, public dialog: MatDialog, private dialogRef: MatDialogRef<AddselectionComponent>) { }

  ngOnInit(): void {
  }

  onSubmit(addSelection: { name: string, startDate: Date, endDate: Date, description: string }) {
    console.log(addSelection);
    this.selectionService.addSelection(addSelection);
  }

  closeDialog() {
    this.dialogRef.close()
    window.location.reload();
  }
}

