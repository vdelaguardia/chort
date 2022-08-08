import { Component, OnInit } from '@angular/core';
import { JQueryStyleEventEmitter } from 'rxjs/internal/observable/fromEvent';
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

    //initialize event listeners on buttons
    this.addChoreDialog();
  }
  
  getChores(): void {
    this.choreSvc.getChores().subscribe(chores => this.chores = chores);
  }

  addChoreDialog(): void {
    //code to launch a dialog box that allows a user to add a scheduled chore to a household
    const dialog: HTMLDialogElement | null = document.getElementById('addChoreDialog') as HTMLDialogElement;    
    const addChoreBtn = document.getElementById('addChoreBtn');
    const closeBtn = document.getElementById('hide');
    if(addChoreBtn != null && dialog != null) {
      addChoreBtn.addEventListener('click', (e) => {
        dialog.show();
      });
    }
    if(closeBtn != null && dialog != null) {
      closeBtn.addEventListener('click', (e) => {
        dialog.close();   
      }); 
    } 
  }

  addChore(chore: ChoreModel): void {
    this.choreSvc.addChore(chore);
  }
}
