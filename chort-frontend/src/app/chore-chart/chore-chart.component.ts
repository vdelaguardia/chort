import { Component, OnInit } from '@angular/core';
import { ChoreModel } from '../models/chore';
import { ChoreService } from '../services/chore.service';

@Component({
  selector: 'app-chore-chart',
  templateUrl: './chore-chart.component.html',
  styleUrls: ['./chore-chart.component.less']
})
export class ChoreChartComponent implements OnInit {

  chores: Array<ChoreModel> = [];

  constructor(public choreSvc: ChoreService) { }

  ngOnInit(): void {
    this.getChores();
    console.log(this.chores);
  }
  
  getChores(): void {
    this.choreSvc.getChores().subscribe(chores => this.chores = chores);
  }
}
