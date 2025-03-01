using Alfredo.NocNoc.Flights;
using Alfredo.NocNoc.GlasClient.Flights;
using Alfredo.NocNoc.GlasClient.Passengers;
using Alfredo.NocNoc.Passengers;
using AutoMapper;

namespace Alfredo.NocNoc;

public class NocNocApplicationAutoMapperProfile : Profile
{
	public NocNocApplicationAutoMapperProfile()
	{
		#region Flights
		CreateMap<FlightSearchRequestDto, GlasFlightSearchRequest>();
		CreateMap<GlasFlight, FlightDto>();
		#endregion

		#region Passengers
		CreateMap<CreatePassengerNameRecordDto, GlasPnrRequest>();
		CreateMap<GlasPnrResponse, PassengerNameRecordDto>();
		#endregion
	}
}
