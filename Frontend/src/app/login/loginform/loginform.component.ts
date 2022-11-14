import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/models/login';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-loginform',
  templateUrl: './loginform.component.html',
  styleUrls: ['./loginform.component.css']
})
export class LoginformComponent implements OnInit {
  token: any;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(login: { username: string, password: string }) {
    console.log(login);
    this.authService.login(login).subscribe((response) => {
      if (response != null) {
        this.token = response;
        console.log(this.token);
        localStorage.setItem('token', this.token.token);
      }
    });
  }

}
