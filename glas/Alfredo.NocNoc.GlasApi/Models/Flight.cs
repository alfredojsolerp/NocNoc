namespace Alfredo.NocNoc.GlasApi.Models
{
	public class Flight
	{
		public required int Id { get; set; }
		public required string Origin { get; set; }
		public required string Destination { get; set; }
		public required DateTime DepartureDate { get; set; }
		public required DateTime ReturnDate { get; set; }
		public required string Airline { get; set; }
		public required double Price { get; set; }
	}
}
