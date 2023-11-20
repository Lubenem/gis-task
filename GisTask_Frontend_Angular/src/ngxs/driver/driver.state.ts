import { Injectable } from '@angular/core';
import { DriverStateModel } from './driver.state.model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { ApiService } from 'src/services/api.service';
import { FetchDrivers } from './driver.actions';
import { tap } from 'rxjs';
import { DriverDto } from 'src/models';

@State<DriverStateModel>({
  name: 'drivers',
  defaults: {
    drivers: [],
  },
})
@Injectable()
export class DriverState {
  constructor(private apiService: ApiService) {}

  @Action(FetchDrivers)
  fetchDrivers({ getState, setState }: StateContext<DriverStateModel>) {
    return this.apiService.getDrivers().pipe(
      tap((result) => {
        const state = getState();
        setState({
          ...state,
          drivers: result,
        });
      })
    );
  }

  @Selector()
  static getDrivers(state: DriverStateModel): DriverDto[] {
    return state.drivers;
  }
}
