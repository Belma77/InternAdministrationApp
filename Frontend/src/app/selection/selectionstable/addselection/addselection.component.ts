import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SelectionsService } from 'src/app/services/selections.service';
import { SelectionstableComponent } from '../selectionstable.component';

@Component({
  selector: 'app-addselection',
  templateUrl: './addselection.component.html',
  styleUrls: ['./addselection.component.css']
})
export class AddselectionComponent implements OnInit {

  constructor(private selectionService: SelectionsService, public dialog: MatDialog, public dialogRef: MatDialogRef<SelectionstableComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }



  onNoClick(): void {
    this.dialogRef.close();
  }

}

