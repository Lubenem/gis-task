import { Injectable } from '@angular/core';
import { TripStateModel } from './trip.state.model';
import { Action, Selector, State, StateContext } from '@ngxs/store';
import { ApiService } from 'src/services/api.service';
import { FetchTrips } from './trip.actions';
import { tap } from 'rxjs';
import { TripDto } from 'src/models';

@State<TripStateModel>({
  name: 'trips',
  defaults: {
    trips: [],
  },
})
@Injectable()
export class TripState {
  constructor(private apiService: ApiService) {}

  @Action(FetchTrips)
  fetchtrips({ getState, setState }: StateContext<TripStateModel>) {
    return this.apiService.getTrips().pipe(
      tap((result) => {
        const state = getState();
        setState({
          ...state,
          trips: result,
        });
      })
    );
  }

  @Selector()
  static getTrips(state: TripStateModel): TripDto[] {
    return state.trips;
  }
}
