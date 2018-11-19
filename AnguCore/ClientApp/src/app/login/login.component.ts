import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";
import { AuthenticationService } from "../authentication.service";
import { LoginModel } from '../shared/models/authentication.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean;
  model: LoginModel;

  constructor(private router: Router, private http: HttpClient, private authService: AuthenticationService) { }

  ngOnInit() {
    this.model = new LoginModel();
  }

  login(form: NgForm) {
    this.authService.login(this.model)
      .subscribe(data => {
              this.invalidLogin = false;
              this.router.navigate(["/"]);
          }, err => {
              this.invalidLogin = true;
          });;
  }
}
