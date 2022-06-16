import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoreChartComponent } from './chore-chart.component';

describe('ChoreChartComponent', () => {
  let component: ChoreChartComponent;
  let fixture: ComponentFixture<ChoreChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChoreChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChoreChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
