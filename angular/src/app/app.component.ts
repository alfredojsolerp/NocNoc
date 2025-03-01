import { Component, OnDestroy, OnInit } from '@angular/core';
import { FlightSearchComponent } from "./modules/flights/components/flight-search/flight-search.component";
import { FlightResultsComponent } from "./modules/flights/components/flight-results/flight-results.component";
import { ReservationFormComponent } from "./modules/flights/components/reservation-form/reservation-form.component";
import { FlightService } from './modules/flights/services/flight.service';
import { Subscription } from 'rxjs';
import { Flight } from './modules/flights/models/flight.model';
import { FlightSearchRequest } from './modules/flights/models/flight-search-request.model';
import { PassengerNameRecordRequest } from './modules/flights/models/pnr-request.model';

@Component({
  selector: 'app-root',
  imports: [
    FlightSearchComponent,
    FlightResultsComponent,
    ReservationFormComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit, OnDestroy {
  private getLocationsSubscription: Subscription | undefined;
  private getFlightsSubscription: Subscription | undefined;
  private checkFlightSubscription: Subscription | undefined;
  private createPnrSubscription: Subscription | undefined;

  locations: string[] = [];
  flights: Flight[] = [];
  selectedFlight: Flight | null = null;

  constructor(private flightService: FlightService) { }

  private getLocationsAsync(): void {
    this.getLocationsSubscription = this.flightService.getLocationsAsync().subscribe({
      next: (data) => {
        this.locations = data;
      },
      error: (error) => {
        console.error('> Error fetching locations: ', error);
      }
    });
  }

  private getFlightsAsync(searchRequest?: FlightSearchRequest): void {
    this.getFlightsSubscription = this.flightService.searchFlightshAsync(searchRequest).subscribe({
      next: (data) => {
        this.flights = data.items;
      },
      error: (error) => {
        console.error('> Error fetching flights: ', error);
      }
    });
  }

  private checkFlightAsync(flight: Flight): void {
    if (flight === null) {
      this.selectedFlight = null;
      return;
    }

    this.checkFlightSubscription = this.flightService.sellFlightAsync(flight.id).subscribe({
      next: (data) => {
        if (data) {
          this.selectedFlight = flight;
        } else {
          alert('El vuelo ya no se encuentra disponible en GLAS');
          this.selectedFlight = null;
        }
      },
      error: (error) => {
        console.error('> Error checking flight: ', error);
      }
    });
  }

  private createPnrSubscriptionAsync(pnr: PassengerNameRecordRequest): void {
    this.getLocationsSubscription = this.flightService.createPnrAsync(pnr).subscribe({
      next: (data) => {
        alert(`PNR creado exitosamente (código de reserva: ${data.bookingReference})`);
      },
      error: (error) => {
        console.error('> Error creating PNR: ', error);
      }
    });
  }

  ngOnInit(): void {
    this.getLocationsAsync();
  }

  ngOnDestroy(): void {
    this.getLocationsSubscription?.unsubscribe();
    this.getFlightsSubscription?.unsubscribe();
    this.checkFlightSubscription?.unsubscribe();
    this.createPnrSubscription?.unsubscribe();
  }

  onFiltersSelected(searchRequest: any) {
    this.getFlightsAsync(searchRequest);
  }

  onFlightSelected(flight: any) {
    this.checkFlightAsync(flight);
  }

  onPnrFormSubmitted(pnr: any) {
    this.createPnrSubscriptionAsync(pnr);
  }
}


