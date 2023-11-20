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
import { DriverDto } from 'src/models';
import { FetchDrivers } from 'src/ngxs/driver/driver.actions';
import { DriverState } from 'src/ngxs/driver/driver.state';

@Component({
  selector: 'app-drivers-table',
  templateUrl: './drivers-table.component.html',
  styleUrls: ['./drivers-table.component.scss'],
})
export class DriversTableComponent {
  drivers!: DriverDto[];
  public driverTableItems!: Observable<GridDataResult>;
  public driverTablePageSize: number = 10;
  public driverTableSkip: number = 0;
  public driverTableSortDescriptor: SortDescriptor[] = [];
  public driverTableFilterTerm: number = null!;

  constructor(private store: Store) {}

  ngOnInit() {
    this.store.select(DriverState.getDrivers).subscribe((drivers) => {
      this.drivers = drivers;
      this.processDriverTableItems();
    });
    this.store.dispatch(new FetchDrivers());
  }

  private processDriverTableItems(): void {
    this.driverTableItems = this.getDrivers(
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

  public getDrivers(
    items: DriverDto[],
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
