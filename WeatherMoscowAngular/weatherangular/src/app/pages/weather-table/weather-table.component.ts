import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WeatherTableService } from '../../shared/services/weather-table.service';
import { Subscription } from 'rxjs';
import { WeatherTableDTO } from '../../models/weather-table.type';
import {MatTableDataSource, MatTableModule} from '@angular/material/table'
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatSort, MatSortModule } from '@angular/material/sort';
import {MatInputModule} from '@angular/material/input';

@Component({
  selector: 'app-weather-table',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule, MatFormFieldModule, MatSortModule, MatInputModule],
  templateUrl: './weather-table.component.html',
  styleUrl: './weather-table.component.scss'
})
export class WeatherTableComponent implements OnInit, OnDestroy {
  displayedColumns: string[] = [
    'date',
    'time',
    'temperature',
    'humidity',
    'dewPoint',
    'pressure',
    'windDirection',
    'windSpeed',
    'cloudiness',
    'cloudinessLowerBound',
    'horizontalVisibility',
    'weatherConditions'
  ];

  @ViewChild(MatPaginator) paginator: MatPaginator | null = null;
  @ViewChild(MatSort) sort: MatSort | null = null;

  private subscriptions$ = new Subscription();

  data = new MatTableDataSource<WeatherTableDTO>([]);

  constructor(private weatherService: WeatherTableService) {}
  ngOnInit(): void {
    this.subscriptions$.add(
      this.weatherService.getTable().subscribe((data: WeatherTableDTO[]) => {
        this.data.data = data;
      })
    )
  }
  ngOnDestroy(): void {
    this.subscriptions$.unsubscribe();
  }

  ngAfterViewInit() {
    this.data.paginator = this.paginator;
    this.data.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.data.filter = filterValue.trim().toLowerCase();

    if (this.data.paginator) {
      this.data.paginator.firstPage();
    }
  }
}
