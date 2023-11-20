import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

type AddTripForm = FormGroup<{
  driverId: FormControl<number>;
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

  ngOnInit() {
    this.addTripForm = new FormGroup({
      driverId: new FormControl(1, {
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

  public onAddTripClick() {}
}
