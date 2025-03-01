using Alfredo.NocNoc.GlasApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfredo.NocNoc.GlasApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PnrController : ControllerBase
	{
		public PnrController()
		{
			
		}

		[HttpPost("CreatePnr")]
		public PnrResponse PostCreatePnr(PnrRequest request)
		{
			return new PnrResponse()
			{
				BookingReference = Guid.NewGuid().ToString(),
				PassengerName = request.PassengerName,
				FlightNumber = request.FlightNumber,
				DepartureDate = request.DepartureDate,
				ReturnDate = request.ReturnDate,
				Origin = request.Origin,
				Destination = request.Destination,
			};
		}
	}
}
