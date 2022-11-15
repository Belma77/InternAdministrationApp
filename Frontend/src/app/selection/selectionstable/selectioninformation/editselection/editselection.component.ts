import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Selections } from 'src/app/models/selections';
import { SelectionsService } from 'src/app/services/selections.service';

@Component({
  selector: 'app-editselection',
  templateUrl: './editselection.component.html',
  styleUrls: ['./editselection.component.css']
})
export class EditselectionComponent implements OnInit {

  constructor(private selectionService: SelectionsService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  onSubmit(editSelection: { SelectionId: number, Name?: string, StartDate?: Date, EndDate?: Date, Description?: string }) {
    editSelection.SelectionId = this.data.selections.id;
    this.selectionService.editSelection(editSelection);
  }
}
