using Alfredo.NocNoc.GlasClient.Flights;
using Alfredo.NocNoc.GlasClient.Passengers;

namespace Alfredo.NocNoc.GlasClient
{
	public interface IGlasApiClient
	{
		Task<IEnumerable<string>> GetFlightLocationsAsync();
		Task<IEnumerable<GlasFlight>> GetFlightsAsync(GlasFlightSearchRequest request);
		Task<bool?> CheckFlightIsAvailableAsync(int flightId);
		Task<GlasPnrResponse?> CreatePnrAsync(GlasPnrRequest request);
	}
}
