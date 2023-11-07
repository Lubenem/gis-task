import { Component, OnInit } from '@angular/core';
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { Observable } from 'rxjs';
import { TableService } from 'src/services/table.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public driverTableItems!: Observable<GridDataResult>;
  public driverTablePageSize: number = 10;
  public driverTableSkip: number = 0;
  public driverTableSortDescriptor: SortDescriptor[] = [];
  public driverTableFilterTerm: number = null!;

  public tripTableItems!: Observable<GridDataResult>;
  public tripTablePageSize: number = 10;
  public tripTableSkip: number = 0;
  public tripTableSortDescriptor: SortDescriptor[] = [];
  public tripTableFilterTerm: number = null!;

  constructor(private tableService: TableService) {}

  ngOnInit() {
    this.loadDrivers();
    this.loadTrips();
  }

  public driverTablePageChange(event: PageChangeEvent): void {
    this.driverTableSkip = event.skip;
    this.loadDrivers();
  }

  public driverTableHandleSortChange(descriptor: SortDescriptor[]): void {
    this.driverTableSortDescriptor = descriptor;
    this.loadDrivers();
  }

  private loadDrivers(): void {
    this.driverTableItems = this.tableService.getDrivers(
      this.driverTableSkip,
      this.driverTablePageSize,
      this.driverTableSortDescriptor,
      this.driverTableFilterTerm
    );
  }

  public tripTablePageChange(event: PageChangeEvent): void {
    this.tripTableSkip = event.skip;
    this.loadTrips();
  }

  public tripTableHandleSortChange(descriptor: SortDescriptor[]): void {
    this.tripTableSortDescriptor = descriptor;
    this.loadTrips();
  }

  private loadTrips(): void {
    this.tripTableItems = this.tableService.getTrips(
      this.tripTableSkip,
      this.tripTablePageSize,
      this.tripTableSortDescriptor,
      this.tripTableFilterTerm
    );
  }
}
