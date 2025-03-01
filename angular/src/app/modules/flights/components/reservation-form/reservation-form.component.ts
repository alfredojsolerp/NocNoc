import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { PassengerNameRecordRequest } from '../../models/pnr-request.model';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { Flight } from '../../models/flight.model';
import { CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-reservation-form',
  imports: [
    MatFormFieldModule,
    FormsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    CurrencyPipe,
    DatePipe
  ],
  templateUrl: './reservation-form.component.html',
  styleUrls: ['./reservation-form.component.css']
})
export class ReservationFormComponent {
  @Input() selectedFlight: Flight | null = null;
  @Output() passengerFormSubmitted = new EventEmitter<PassengerNameRecordRequest>();

  passengerForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.passengerForm = this.formBuilder.group({
      passengerName: ['', [Validators.required]],
      passengerSurname: ['', [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.passengerForm.valid) {
      this.passengerFormSubmitted.emit(new PassengerNameRecordRequest({
        passengerName: `${this.passengerForm.get('passengerName')?.value} ${this.passengerForm.get('passengerSurname')?.value}`,
        flightNumber: this.selectedFlight?.id.toString(),
        departureDate: this.selectedFlight?.departureDate,
        returnDate: this.selectedFlight?.returnDate,
        origin: this.selectedFlight?.returnDate,
        destination: this.selectedFlight?.destination,
      }));
      
      this.passengerForm.reset();
    } else {
      alert('Llene todos los campos!');
    }
  }
}
