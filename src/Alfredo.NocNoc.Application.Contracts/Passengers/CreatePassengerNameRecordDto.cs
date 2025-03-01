using System;
using System.ComponentModel.DataAnnotations;

namespace Alfredo.NocNoc.Passengers
{
	public class CreatePassengerNameRecordDto
	{
		[Required]
		public required string PassengerName { get; set; }

		[Required]
		public required string FlightNumber { get; set; }

		[Required]
		public required DateTime DepartureDate { get; set; }

		[Required]
		public required DateTime ReturnDate { get; set; }

		[Required]
		public required string Origin { get; set; }

		[Required]
		public required string Destination { get; set; }
	}
}
