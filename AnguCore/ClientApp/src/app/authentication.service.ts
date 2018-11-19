import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";
import { tap, catchError } from 'rxjs/operators';
import { LoginModel, RegisterModel } from './shared/models/authentication.model';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  invalidLogin: boolean;

  constructor(private router: Router, private http: HttpClient) { }

  login(model: LoginModel) {
    return this.http.post('api/auth/login', model, httpOptions).pipe(
      tap((data: any) => {
        localStorage.setItem("jwt", data.token);
      })
    );
  }

  register(model: RegisterModel) {
    return this.http.post('api/auth/register', model, httpOptions).pipe(
      tap((data: any) => {
        localStorage.setItem("jwt", data.token);
      })
    );
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('jwt');
  }
}
