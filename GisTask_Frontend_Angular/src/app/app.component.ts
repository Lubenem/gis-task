import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { Observable } from 'rxjs';
import { DriverDto, TripDto } from 'src/models';
import { FetchDrivers } from 'src/ngxs/driver/driver.actions';
import { DriverState } from 'src/ngxs/driver/driver.state';
import { FetchTrips } from 'src/ngxs/trip/trip.actions';
import { TripState } from 'src/ngxs/trip/trip.state';
import { TableService } from 'src/services/table.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  drivers!: DriverDto[];
  public driverTableItems!: Observable<GridDataResult>;
  public driverTablePageSize: number = 10;
  public driverTableSkip: number = 0;
  public driverTableSortDescriptor: SortDescriptor[] = [];
  public driverTableFilterTerm: number = null!;
  
  trips!: TripDto[];
  public tripTableItems!: Observable<GridDataResult>;
  public tripTablePageSize: number = 10;
  public tripTableSkip: number = 0;
  public tripTableSortDescriptor: SortDescriptor[] = [];
  public tripTableFilterTerm: number = null!;

  constructor(private tableService: TableService, private store: Store) {}

  ngOnInit() {
    this.store.select(DriverState.getDrivers).subscribe((drivers) => {
      this.drivers = drivers;
      this.processDriverTableItems();
    });
    this.store.dispatch(new FetchDrivers());

    this.store.select(TripState.getTrips).subscribe((trips) => {
      this.trips = trips;
      this.processTripTableItems();
    });
    this.store.dispatch(new FetchTrips());
  }

  private processDriverTableItems(): void {
    this.driverTableItems = this.tableService.getDrivers(
      this.drivers,
      this.driverTableSkip,
      this.driverTablePageSize,
      this.driverTableSortDescriptor,
      this.driverTableFilterTerm
    );
  }

  public driverTablePageChange(event: PageChangeEvent): void {
    this.driverTableSkip = event.skip;
    this.processDriverTableItems();
  }

  public driverTableHandleSortChange(descriptor: SortDescriptor[]): void {
    this.driverTableSortDescriptor = descriptor;
    this.processDriverTableItems();
  }

  private processTripTableItems(): void {
    this.tripTableItems = this.tableService.getTrips(
      this.trips,
      this.tripTableSkip,
      this.tripTablePageSize,
      this.tripTableSortDescriptor,
      this.tripTableFilterTerm
    );
  }

  public tripTablePageChange(event: PageChangeEvent): void {
    this.tripTableSkip = event.skip;
    this.processTripTableItems();
  }

  public tripTableHandleSortChange(descriptor: SortDescriptor[]): void {
    this.tripTableSortDescriptor = descriptor;
    this.processTripTableItems();
  }
}
