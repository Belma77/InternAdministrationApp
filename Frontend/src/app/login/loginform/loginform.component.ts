import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
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
    private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(login: { username: string, password: string }) {
    console.log(login);
    this.authService.login(login).subscribe((response) => {
      if (response != null) {
        this.token = response;
        console.log(this.token);
        localStorage.setItem('token', this.token.token);
        this.router.navigate(['/applications']);
      }
    });
  }
}
