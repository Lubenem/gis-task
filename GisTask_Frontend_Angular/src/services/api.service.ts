import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DriverDto, TripDto } from 'src/models';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = 'http://localhost:5244';

  constructor(private http: HttpClient) {}

  getDrivers(): Observable<DriverDto[]> {
    return this.http.get<DriverDto[]>(`${this.baseUrl}/Driver/GetDrivers`);
  }

  addDriver(driver: DriverDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/Driver/AddDriver`, driver);
  }

  removeDriver(driverId: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/Driver/RemoveDriver`, { driverId });
  }

  getTrips(): Observable<TripDto[]> {
    return this.http.get<TripDto[]>(`${this.baseUrl}/Trip/GetTrips`);
  }

  addTrip(trip: TripDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/Trip/AddTrip`, trip);
  }

  removeTrip(tripId: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/Trip/RemoveTrip`, { tripId });
  }
}
