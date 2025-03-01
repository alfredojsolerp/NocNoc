namespace Alfredo.NocNoc.GlasClient.Passengers
{
	public class GlasPnrRequest
	{
		public required string PassengerName { get; set; }
		public required string FlightNumber { get; set; }
		public required DateTime DepartureDate { get; set; }
		public required DateTime ReturnDate { get; set; }
		public required string Origin { get; set; }
		public required string Destination { get; set; }

		public bool IsValidObject()
		{
			return !(
				string.IsNullOrEmpty(PassengerName) ||
				string.IsNullOrEmpty(FlightNumber) ||
				string.IsNullOrEmpty(Origin) ||
				string.IsNullOrEmpty(Destination) ||
				Origin == Destination ||
				DepartureDate > ReturnDate
			);
		}
	}
}
