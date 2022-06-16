import { Component, OnInit } from '@angular/core';
import { ChoreModel } from '../models/chore';

@Component({
  selector: 'app-chore-chart',
  templateUrl: './chore-chart.component.html',
  styleUrls: ['./chore-chart.component.less']
})
export class ChoreChartComponent implements OnInit {

  chores: Array<ChoreModel> = [{id: 1, name: "Wash Dishes"}];

  constructor() { }

  ngOnInit(): void {
  }

}
