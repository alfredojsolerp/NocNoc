namespace Alfredo.NocNoc.GlasApi.Models
{
	public class FlightSearchRequest
	{
		public string? Origin { get; set; }
		public string? Destination { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
	}
}
