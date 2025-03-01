namespace Alfredo.NocNoc.GlasClient.Flights
{
	public class GlasFlightSearchRequest
	{
		public string? Origin { get; set; }
		public string? Destination { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
	}
}
