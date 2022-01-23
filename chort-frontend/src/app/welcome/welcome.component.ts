import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.less']
})
export class WelcomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  login(): void {
    console.log('login clicked');
    this.router.navigate(['/login']);
  }

  signup(): void {
    console.log('signup clicked');
    this.router.navigate(['/signup']);
  }

}
