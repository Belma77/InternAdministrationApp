import { Component, OnInit } from '@angular/core';
import { SelectionsService } from 'src/app/services/selections.service';

@Component({
  selector: 'app-addselection',
  templateUrl: './addselection.component.html',
  styleUrls: ['./addselection.component.css']
})
export class AddselectionComponent implements OnInit {

  constructor(private selectionService: SelectionsService) { }

  ngOnInit(): void {
  }

  onSubmit(addSelection: { name: string, startDate: Date, endDate: Date, description: string }) {
    console.log(addSelection);
    this.selectionService.addSelection(addSelection);
  }
}

