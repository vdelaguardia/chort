import { Component, OnInit } from '@angular/core';
import { Email } from '../models/email';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  email: Email;

  constructor() { }

  ngOnInit(): void {
    this.email.invalid = true;
  }

  onLoginSubmit(): void {
    console.log('login submitted');
  }

  getErrorMessage(field: string): string{
    if (field === 'email' && this.email.invalid) {
      return 'Invalid email address. Please enter a valid email.';
    }
  }
}
