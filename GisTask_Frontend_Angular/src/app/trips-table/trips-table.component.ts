import { Component } from '@angular/core';
import { Store } from '@ngxs/store';
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import {
  DataResult,
  orderBy,
  process,
  SortDescriptor,
} from '@progress/kendo-data-query';
import { Observable, of } from 'rxjs';
import { TripDto } from 'src/models';
import { FetchTrips } from 'src/ngxs/trip/trip.actions';
import { TripState } from 'src/ngxs/trip/trip.state';

@Component({
  selector: 'app-trips-table',
  templateUrl: './trips-table.component.html',
  styleUrls: ['./trips-table.component.scss'],
})
export class TripsTableComponent {
  trips!: TripDto[];
  public tripTableItems!: Observable<GridDataResult>;
  public tripTablePageSize: number = 10;
  public tripTableSkip: number = 0;
  public tripTableSortDescriptor: SortDescriptor[] = [];
  public tripTableFilterTerm: number = null!;

  constructor(private store: Store) {}

  ngOnInit() {
    this.store.select(TripState.getTrips).subscribe((trips) => {
      this.trips = trips;
      this.processTripTableItems();
    });
    this.store.dispatch(new FetchTrips());
  }

  private processTripTableItems(): void {
    this.tripTableItems = this.getTrips(
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

  public getTrips(
    items: TripDto[],
    skip: number,
    pageSize: number,
    sortDescriptor: SortDescriptor[],
    filterTerm: number | null
  ): Observable<DataResult> {
    let data = orderBy(items, sortDescriptor);
    if (filterTerm) {
      data = process(data, {
        filter: {
          logic: 'and',
          filters: [
            {
              field: 'CategoryID',
              operator: 'eq',
              value: filterTerm,
            },
          ],
        },
      }).data;
    }
    const pagedData = data.slice(skip, skip + pageSize);
    return of({
      data: pagedData,
      total: data.length,
    });
  }
}
