export interface TripDto {
  id?: number;
  driverId?: number | null;
  passengerCount?: number;
  startTime?: Date;
  endTime?: Date;
}
