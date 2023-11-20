import { TripDto } from 'src/models';

export class FetchTrips {
  static readonly type = '[Trip] Fetch';
}

export class AddTrip {
  static readonly type = '[Trip] Add';
  constructor(public trip: TripDto) {}
}
