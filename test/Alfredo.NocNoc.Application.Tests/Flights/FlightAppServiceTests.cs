using Alfredo.NocNoc.Flights;
using Alfredo.NocNoc.GlasClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class FlightAppServiceTests
{
	private readonly Mock<IGlasApiClient> _mockGlasApiClient;
	private readonly FlightAppService _flightAppService;

	public FlightAppServiceTests()
	{
		_mockGlasApiClient = new Mock<IGlasApiClient>();
		_flightAppService = new FlightAppService(_mockGlasApiClient.Object);
	}

	[Fact]
	public async Task GetLocationsAsync_ShouldReturnFlightLocations()
	{
		// Arrange
		var expectedLocations = new List<string> { "Montevideo", "Punta del Este" };

		_mockGlasApiClient
			.Setup(client => client.GetFlightLocationsAsync())
			.ReturnsAsync(expectedLocations);

		// Act
		var result = await _flightAppService.GetLocationsAsync();

		// Assert
		Assert.NotNull(result);
		Assert.Equal(expectedLocations.Count, result.Count());
		Assert.Equal(expectedLocations, result);
	}
}
