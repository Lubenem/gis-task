import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngxs/store';
import { TripDto } from 'src/models';
import { AddTrip } from 'src/ngxs/trip/trip.actions';

type AddTripForm = FormGroup<{
  driverId: FormControl<number>;
  passengerCount: FormControl<number>;
  start: FormControl<Date>;
  end: FormControl<Date>;
}>;

@Component({
  selector: 'app-add-trip-form',
  templateUrl: './add-trip-form.component.html',
  styleUrls: ['./add-trip-form.component.scss'],
})
export class AddTripFormComponent {
  addTripForm!: AddTripForm;

  constructor(private store: Store) {}

  ngOnInit() {
    this.addTripForm = new FormGroup({
      driverId: new FormControl(1, {
        nonNullable: true,
      }),
      passengerCount: new FormControl(1, {
        nonNullable: true,
      }),
      start: new FormControl(new Date(), {
        nonNullable: true,
      }),
      end: new FormControl(new Date(), {
        nonNullable: true,
      }),
    });
  }

  public onAddTripClick() {
    if (!this.addTripForm.valid) {
      return;
    }
    let newTrip: TripDto = {
      driverId: this.addTripForm.controls.driverId.value,
      passengerCount: this.addTripForm.controls.passengerCount.value,
      startTime: this.addTripForm.controls.start.value,
      endTime: this.addTripForm.controls.end.value,
    };
    this.store.dispatch(new AddTrip(newTrip)).subscribe({
      next: () => {
        window.location.reload();
      },
    });
  }
}
