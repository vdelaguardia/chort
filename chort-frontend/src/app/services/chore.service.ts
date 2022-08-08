import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ChoreModel } from '../models/chore';
import { CHORES } from '../mock-chores';

@Injectable({
  providedIn: 'root'
})
export class ChoreService {

  constructor() { }

  getChores(): Observable<ChoreModel[]> {
    const chores = of(CHORES);
    return chores;
  }

  addChore(chore: ChoreModel): void {

  }
}
