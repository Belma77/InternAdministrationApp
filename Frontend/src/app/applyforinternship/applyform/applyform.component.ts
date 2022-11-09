import { Component, OnInit } from '@angular/core';
import { ApplicationService } from 'src/app/services/application.service';

@Component({
  selector: 'app-applyform',
  templateUrl: './applyform.component.html',
  styleUrls: ['./applyform.component.css']
})
export class ApplyformComponent implements OnInit {

  constructor(private appService: ApplicationService) { }

  ngOnInit(): void {
  }

  onSubmit(applicationData: { firstName: string, lastName: string, email: string, educationLevel: string, coverLetter: string, cv: string }) {
    this.appService.storeApplication(applicationData);
  }

}
