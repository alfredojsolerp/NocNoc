using System;
using Volo.Abp.Application.Dtos;

namespace Alfredo.NocNoc.Flights
{
    public class FlightSearchRequestDto : PagedResultRequestDto
    {
		public string? Origin { get; set; }
		public string? Destination { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
	}
}
