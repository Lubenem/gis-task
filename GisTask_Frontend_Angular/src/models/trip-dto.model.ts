export interface TripDto { 
    id?: number;
    driverId?: number | null;
    passengerCount?: number;
    startTime?: string;
    endTime?: string;
}

