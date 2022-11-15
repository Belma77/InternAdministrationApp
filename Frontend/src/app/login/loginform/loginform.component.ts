import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-loginform',
  templateUrl: './loginform.component.html',
  styleUrls: ['./loginform.component.css']
})
export class LoginformComponent implements OnInit {
  token: any;
  loggedIn: boolean = false;

  constructor(private authService: AuthService,
    private router: Router,
    private snackbar: MatSnackBar) { }

  ngOnInit(): void {
  }

  onSubmit(login: { username: string, password: string }) {
    this.authService.login(login).subscribe((response) => {
      if (response != null) {
        this.token = response;
        localStorage.setItem('token', this.token.token);
        this.snackbar.open('Sucessfully logged in', null, {});
        this.router.navigate(['/applications']);
      }
    });
  }
}
