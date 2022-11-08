import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css']
})
export class ApplicantComponent implements OnInit {
  addComment: boolean = true;
  visible: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  openCommentSection() {
    this.addComment = !this.visible;
    this.visible = !this.visible;
  }

}
