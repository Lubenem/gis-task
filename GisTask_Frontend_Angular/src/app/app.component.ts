import { Component, OnInit } from '@angular/core';
import { DriverDto, TripDto } from 'src/models';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'gistask-app';
  drivers: DriverDto[] = [];
  trips: TripDto[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.apiService.getDrivers().subscribe({
      next: (drivers) => {
        this.drivers = drivers;
      },
    });
    this.apiService.getTrips().subscribe({
      next: (trips) => {
        this.trips = trips;
      },
    });
  }
}
