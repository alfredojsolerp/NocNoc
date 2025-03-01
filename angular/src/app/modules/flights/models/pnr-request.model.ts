export class PassengerNameRecordRequest {
    passengerName: string = '';
    flightNumber: string = '';
    origin: string = '';
    destination: string = '';
    departureDate: string = '';
    returnDate: string = '';

    constructor(init?: Partial<PassengerNameRecordRequest>) {
        Object.assign(this, init);
    }
}