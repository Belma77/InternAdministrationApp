import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-selectioninformation',
  templateUrl: './selectioninformation.component.html',
  styleUrls: ['./selectioninformation.component.css']
})
export class SelectioninformationComponent implements OnInit {
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
