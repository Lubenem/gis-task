import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxsModule } from '@ngxs/store';
import { DriverState } from 'src/ngxs/driver/driver.state';
import { TripState } from 'src/ngxs/trip/trip.state';
import { TripsTableComponent } from './trips-table/trips-table.component';
import { DriversTableComponent } from './drivers-table/drivers-table.component';
import { AddTripFormComponent } from './add-trip-form/add-trip-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TripsTableComponent,
    DriversTableComponent,
    AddTripFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    GridModule,
    BrowserAnimationsModule,
    NgxsModule.forRoot([DriverState, TripState]),
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
