using Alfredo.NocNoc.GlasApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfredo.NocNoc.GlasApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FlightController : ControllerBase
	{
		private const int _flightsCount = 30;

		private string[] _southAmericanCapitals = [
			"Buenos Aires", "La Paz", "Brasília",
			"Santiago", "Bogotá", "Quito", "Asunción",
			"Lima", "Montevideo", "Caracas"
		];

		private string[] _airlines = [
			"Avianca", "Jetsmart", "Aeromás",
			"Azul", "Copa", "LATAM", "Paranair",
			"Iberia", "SKY", "American"
		];

		private Random _randomNumberGenerator = new Random();

		public FlightController()
		{

		}

		[HttpGet("Locations")]
		public IEnumerable<string> GetLocations()
		{
			return _southAmericanCapitals;
		}

		[HttpGet("Search")]
		public IEnumerable<Flight> GetSearch([FromQuery]FlightSearchRequest request)
		{
			Flight[] flights = new Flight[_flightsCount];

			for (int i = 0; i < _flightsCount; i++)
			{
				string origin = _southAmericanCapitals[_randomNumberGenerator.Next(_southAmericanCapitals.Length)];
				string destination;

				do
				{
					destination = _southAmericanCapitals[_randomNumberGenerator.Next(_southAmericanCapitals.Length)];
				}
				while (destination == origin);

				double price;

				do
				{
					price = Math.Round(_randomNumberGenerator.NextDouble() * 1000, 2);
				}
				while (price < 100);


				flights[i] = new Flight()
				{
					Id = i + 1,
					Origin = origin,
					Destination = destination,
					DepartureDate = DateTime.UtcNow.AddDays(i),
					ReturnDate = DateTime.UtcNow.AddDays(i + 1),
					Airline = _airlines[_randomNumberGenerator.Next(_airlines.Length)],
					Price = price,
				};
			}

			return flights.Where(x =>
				(request.Origin == null || x.Origin == request.Origin) &&
				(request.Destination == null || x.Destination == request.Destination) &&
				(request.FromDate == null || x.DepartureDate >= request.FromDate) &&
				(request.ToDate == null || x.ReturnDate <= request.ToDate));
		}

		[HttpGet("Sell/{flightId}")]
		public bool GetSell([FromRoute]int flightId)
		{
			return flightId % 2 == 0;
		}
	}
}
