using Alfredo.NocNoc.GlasClient.Flights;
using Alfredo.NocNoc.GlasClient.Passengers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Alfredo.NocNoc.GlasClient
{
	public class GlasApiClient : IGlasApiClient
	{
		private readonly RestClient _restClient;

		public GlasApiClient(IConfiguration configuration)
		{
			_restClient = new RestClient(configuration[NocNocGlasClientConsts.GlasApiBaseUrl] ?? string.Empty);
		}

		private void AddParametersToSearchFlightRequest(RestRequest restRequest, GlasFlightSearchRequest searchRequest)
		{
			if (searchRequest.Origin != null)
			{
				restRequest.AddParameter(nameof(searchRequest.Origin), searchRequest.Origin);
			}

			if (searchRequest.Destination != null)
			{
				restRequest.AddParameter(nameof(searchRequest.Destination), searchRequest.Destination);
			}

			if (searchRequest.FromDate != null)
			{
				restRequest.AddParameter(nameof(searchRequest.FromDate), searchRequest.FromDate.ToString());
			}

			if (searchRequest.ToDate != null)
			{
				restRequest.AddParameter(nameof(searchRequest.ToDate), searchRequest.ToDate.ToString());
			}
		}

		public async Task<IEnumerable<string>> GetFlightLocationsAsync()
		{
			try
			{
				RestRequest request = new RestRequest(NocNocGlasClientConsts.FlightLocations, Method.Get);
				RestResponse response = await _restClient.ExecuteAsync(request);

				if (response.IsSuccessful && response.Content != null)
				{
					return JsonConvert.DeserializeObject<IEnumerable<string>>(response.Content) ?? [];
				}				
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Request error: {ex.Message}");
			}

			return [];
		}

		public async Task<IEnumerable<GlasFlight>> GetFlightsAsync(GlasFlightSearchRequest request)
		{
			try
			{
				RestRequest restRequest = new RestRequest(NocNocGlasClientConsts.FlightSearch, Method.Get);
				AddParametersToSearchFlightRequest(restRequest, request);
				RestResponse response = await _restClient.ExecuteAsync(restRequest);

				if (response.IsSuccessful && response.Content != null)
				{
					return JsonConvert.DeserializeObject<IEnumerable<GlasFlight>>(response.Content) ?? [];
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Request error: {ex.Message}");
			}

			return [];
		}

		public async Task<bool?> CheckFlightIsAvailableAsync(int flightId)
		{
			try
			{
				RestRequest request = new RestRequest($"{NocNocGlasClientConsts.FlightSell}/{flightId}", Method.Get);
				RestResponse response = await _restClient.ExecuteAsync(request);

				if (response.IsSuccessful && response.Content != null)
				{
					return JsonConvert.DeserializeObject<bool>(response.Content);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Request error: {ex.Message}");
			}

			return null;
		}

		public async Task<GlasPnrResponse?> CreatePnrAsync(GlasPnrRequest request)
		{
			if (!request.IsValidObject())
			{
				return null;
			}

			try
			{
				RestRequest restRequest = new RestRequest(NocNocGlasClientConsts.PnrCreate, Method.Post);
				restRequest.AddHeader(NocNocGlasClientConsts.ContentType, NocNocGlasClientConsts.ContentTypeApplicationJson);
				restRequest.AddJsonBody(request);
				RestResponse response = await _restClient.ExecuteAsync(restRequest);

				if (response.IsSuccessful && response.Content != null)
				{
					return JsonConvert.DeserializeObject<GlasPnrResponse>(response.Content);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Request error: {ex.Message}");
			}

			return null;
		}		
	}
}
