namespace Alfredo.NocNoc.GlasApi.Models
{
	public class PnrRequest
	{
		public required string PassengerName { get; set; }
		public required string FlightNumber { get; set; }
		public required DateTime DepartureDate { get; set; }
		public required DateTime ReturnDate { get; set; }
		public required string Origin { get; set; }
		public required string Destination { get; set; }
	}
}
