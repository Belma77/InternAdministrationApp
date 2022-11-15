import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  @Input() sideNavStatus: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  signOut() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
