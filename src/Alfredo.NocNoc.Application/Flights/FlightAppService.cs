using Alfredo.NocNoc.GlasClient;
using Alfredo.NocNoc.GlasClient.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Alfredo.NocNoc.Flights
{
	public class FlightAppService : NocNocAppService, IFlightAppService
	{
		private readonly IGlasApiClient _glasApiClient;

		public FlightAppService(IGlasApiClient glasApiClient)
		{
			_glasApiClient = glasApiClient;
		}

		public async Task<IEnumerable<string>> GetLocationsAsync()
		{
			return await _glasApiClient.GetFlightLocationsAsync();
		}

		public async Task<PagedResultDto<FlightDto>> GetSearchAsync(FlightSearchRequestDto request)
		{
			IEnumerable<GlasFlight> flights = await _glasApiClient.GetFlightsAsync(ObjectMapper.Map<FlightSearchRequestDto, GlasFlightSearchRequest>(request));

			return new PagedResultDto<FlightDto>()
			{
				Items = ObjectMapper.Map<IEnumerable<GlasFlight>, List<FlightDto>>(flights.Skip(request.SkipCount).Take(request.MaxResultCount)),
				TotalCount = flights.Count(),
			};
		}

		public async Task<bool?> GetSellAsync(int flightId)
		{
			return await _glasApiClient.CheckFlightIsAvailableAsync(flightId);
		}
	}
}
