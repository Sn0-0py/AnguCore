import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";
import { AuthenticationService } from "../authentication.service";
import { RegisterModel } from '../shared/models/authentication.model';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: RegisterModel;

  constructor(private router: Router, private http: HttpClient, private authService: AuthenticationService) { }

  ngOnInit() {
    this.model = new RegisterModel();
  }
  
  register(form: NgForm) {
    this.authService.register(this.model)
      .subscribe(data => {
        this.router.navigate(["/"]);
      });
  }
}
