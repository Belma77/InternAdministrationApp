import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApplicantsService } from 'src/app/services/applicants.service';

@Component({
  selector: 'app-applyform',
  templateUrl: './applyform.component.html',
  styleUrls: ['./applyform.component.css']
})
export class ApplyformComponent implements OnInit {

  constructor(private appService: ApplicantsService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
  }

  onSubmit(applicationData: { firstName: string, lastName: string, email: string, educationLevel: string, coverLetter: string, cv: string }) {
    this.appService.storeApplication(applicationData);
  }
}
