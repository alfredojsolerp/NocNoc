import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-flight-results',
  imports: [CurrencyPipe, DatePipe],
  templateUrl: './flight-results.component.html',
  styleUrls: ['./flight-results.component.css'],
})
export class FlightResultsComponent {
  @Input() flights: any[] = [];
  @Output() flightSelected = new EventEmitter<any>();

  selectFlight(flight: any) {
    this.flightSelected.emit(flight);
  }
}
