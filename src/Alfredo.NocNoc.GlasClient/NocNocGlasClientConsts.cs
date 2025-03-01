namespace Alfredo.NocNoc.GlasClient
{
    public static class NocNocGlasClientConsts
	{
		#region Shared
		public const string GlasApiBaseUrl = "GlasApi:BaseUrl";
		public const string ContentType = "Content-Type";
		public const string ContentTypeApplicationJson = "application/json";
		#endregion

		#region Flights
		public const string FlightController = "Flight";
		public const string FlightLocations = $"{FlightController}/Locations";
		public const string FlightSearch = $"{FlightController}/Search";
		public const string FlightSell = $"{FlightController}/Sell";
		#endregion

		#region Passengers
		public const string PnrController = "Pnr";
		public const string PnrCreate = $"{PnrController}/CreatePnr";
		#endregion
	}
}
