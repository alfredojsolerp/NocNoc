using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Alfredo.NocNoc.Flights
{
	public interface IFlightAppService
	{
		Task<IEnumerable<string>> GetLocationsAsync();
		Task<PagedResultDto<FlightDto>> GetSearchAsync(FlightSearchRequestDto request);
		Task<bool?> GetSellAsync(int flightId);
	}
}
