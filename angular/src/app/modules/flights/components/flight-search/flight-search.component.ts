import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { FlightSearchRequest } from '../../models/flight-search-request.model';
import { DateUtils } from '../../../core/utils/date-utils';

@Component({
  selector: 'app-flight-search',
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.css']
})
export class FlightSearchComponent {
  @Input() locations: string[] = [];
  @Output() filtersSelected = new EventEmitter<FlightSearchRequest>();

  selectedOrigin: string | null = '';
  selectedDestination: string | null  = '';
  datePickerMinStart: Date = new Date();
  datePickerStart = new FormControl(null, Validators.required);
  datePickerEnd = new FormControl(null, Validators.required);

  filters = {
    origin: '',
    destination: '',
    departureDate: '',
    returnDate: ''
  };

  onSearchButtonClick() {
    if (this.selectedOrigin && this.selectedDestination && this.selectedOrigin === this.selectedDestination) {
      alert('Origen y Destino deben ser distintos');
      return;
    }

    const fromDate = this.datePickerStart.value === null ? undefined : DateUtils.formatDateForBackend(this.datePickerStart.value);
    const toDate = this.datePickerEnd.value === null ? undefined : DateUtils.formatDateForBackend(this.datePickerEnd.value);

    this.filtersSelected.emit(new FlightSearchRequest({
      origin: this.selectedOrigin ?? undefined,
      destination: this.selectedDestination ?? undefined,
      fromDate: fromDate,
      toDate: toDate,
    }));
  }

  onResetButtonClick(): void {
    this.selectedOrigin = null;
    this.selectedDestination = null;
    this.datePickerStart.setValue(null);
    this.datePickerEnd.setValue(null);   
    this.onSearchButtonClick();
  }
}
