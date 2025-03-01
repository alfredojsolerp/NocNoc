import { PaginatedRequest } from "../../core/models/paginated-request.model";

export class FlightSearchRequest implements PaginatedRequest {
    skipCount: number = 0;
    maxResultCount: number = 0;
    origin?: string;
    destination?: string;
    fromDate?: string;
    toDate?: string;

    constructor(init?: Partial<FlightSearchRequest>) {
        Object.assign(this, init);
    }
}