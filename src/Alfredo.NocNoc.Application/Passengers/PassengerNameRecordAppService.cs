using Alfredo.NocNoc.GlasClient;
using Alfredo.NocNoc.GlasClient.Passengers;
using System.Threading.Tasks;

namespace Alfredo.NocNoc.Passengers
{
	public class PassengerNameRecordAppService : NocNocAppService, IPassengerNameRecordAppService
	{
		private readonly IGlasApiClient _glasApiClient;

		public PassengerNameRecordAppService(IGlasApiClient glasApiClient)
		{
			_glasApiClient = glasApiClient;
		}

		public async Task<PassengerNameRecordDto?> CreateAsync(CreatePassengerNameRecordDto request)
		{
			var mappedRequest = ObjectMapper.Map<CreatePassengerNameRecordDto, GlasPnrRequest>(request);
			var response = await _glasApiClient.CreatePnrAsync(mappedRequest);
			return response != null ? ObjectMapper.Map<GlasPnrResponse, PassengerNameRecordDto>(response) : null;
		}
	}
}
