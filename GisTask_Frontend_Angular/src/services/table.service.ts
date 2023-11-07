import { Injectable } from '@angular/core';
import {
  DataResult,
  orderBy,
  process,
  SortDescriptor,
} from '@progress/kendo-data-query';
import { map, Observable, of } from 'rxjs';
import { ApiService } from './api.service';
import { DriverDto, TripDto } from 'src/models';

@Injectable({
  providedIn: 'root',
})
export class TableService {
  constructor(private apiService: ApiService) {}

  public getDrivers(
    skip: number,
    pageSize: number,
    sortDescriptor: SortDescriptor[],
    filterTerm: number | null
  ): Observable<DataResult> {
    return this.apiService.getDrivers().pipe(
      map((response: DriverDto[]) => {
        let data = orderBy(response, sortDescriptor);
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
        return {
          data: pagedData,
          total: data.length,
        };
      })
    );
  }

  public getTrips(
    skip: number,
    pageSize: number,
    sortDescriptor: SortDescriptor[],
    filterTerm: number | null
  ): Observable<DataResult> {
    return this.apiService.getTrips().pipe(
      map((response: TripDto[]) => {
        let data = orderBy(response, sortDescriptor);
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
        return {
          data: pagedData,
          total: data.length,
        };
      })
    );
  }
}
