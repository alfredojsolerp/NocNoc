import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PassengerNameRecordRequest } from '../models/pnr-request.model';
import { PassengerNameRecord } from '../models/pnr.model';
import { PaginatedResponse } from '../../core/models/paginated-response.model';
import { Flight } from '../models/flight.model';
import { FlightSearchRequest } from '../models/flight-search-request.model';

@Injectable({
    providedIn: 'root'
})
export class FlightService {
    private apiUrl = 'https://localhost:44334/api/app';

    constructor(private http: HttpClient) { }

    getLocationsAsync(): Observable<string[]> {
        return this.http.get<string[]>(`${this.apiUrl}/flight/locations`);
    }

    searchFlightshAsync(searchRequest?: FlightSearchRequest): Observable<PaginatedResponse<Flight>> {
        let params = new HttpParams();

        if (searchRequest?.origin) {
            params = params.set('origin', searchRequest.origin);
        }

        if (searchRequest?.destination) {
            params = params.set('destination', searchRequest.destination);
        }

        if (searchRequest?.fromDate) {
            params = params.set('fromDate', searchRequest?.fromDate);
        }

        if (searchRequest?.toDate) {
            params = params.set('toDate', searchRequest?.toDate);
        }

        return this.http.get<PaginatedResponse<Flight>>(`${this.apiUrl}/flight/search`, { params });
    }

    sellFlightAsync(flightId: number): Observable<boolean> {
        return this.http.get<boolean>(`${this.apiUrl}/flight/sell/${flightId}`);
    }

    createPnrAsync(pnrData: PassengerNameRecordRequest): Observable<PassengerNameRecord> {
        return this.http.post<PassengerNameRecord>(`${this.apiUrl}/passenger-name-record`, pnrData);
    }
}
