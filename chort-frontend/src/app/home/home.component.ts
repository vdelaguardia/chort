import { Component, OnInit } from '@angular/core';
import { Chore } from '../models/chore';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {
  public userId: number = 1;
  public homeAddress: string = "7512 Canton Ave";
  public chores: Array<Chore> = [
    {
      id: 1,
      name: "Sweep Kitchen",
      assigneeId: 1,
      difficulty: 1,
      frequency: {
        id: 1,
        description: "Daily"
      },
      lastCompleted: new Date()
    },
    {
      id: 2,
      name: "Clean Bathroom",
      assigneeId: 1,
      difficulty: 3,
      frequency: {
        id: 2,
        description: "Weekly"
      },
      lastCompleted: new Date()
    },
    {
      id: 3,
      name: "Dust Blinds",
      assigneeId: 1,
      difficulty: 3,
      frequency: {
        id: 2,
        description: "Monthly"
      },
      lastCompleted: new Date()
    },
  ];

  public dailyChores: Array<Chore>;
  public weeklyChores: Array<Chore>;
  public monthlyChores: Array<Chore>;

  constructor() {
    this.dailyChores = this.chores.filter(chore => chore.frequency.description == "Daily");
    this.weeklyChores = this.chores.filter(chore => chore.frequency.description == "Weekly");
    this.monthlyChores = this.chores.filter(chore => chore.frequency.description == "Monthly");
  }

  ngOnInit(): void {
  }



}
