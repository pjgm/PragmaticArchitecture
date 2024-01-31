using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;

namespace IntegrationTests.Endpoints.Listings;

public class CreateListingTests : IClassFixture<RealEstatePortalApiFactory>
{
    private readonly HttpClient _httpClient;

    public CreateListingTests(RealEstatePortalApiFactory apiFactory)
    {
        _httpClient = apiFactory.CreateClient();
    }

    [Fact]
    public async Task CreateListing_WithValidListing_ShouldCreateListing()
    {
        var newProperty = new
        {
            rooms = 3,
            area = 100.12,
            floors = 1
        };

        var newPropJson = JsonSerializer.Serialize(newProperty);

        var response = await _httpClient.PostAsync("property", new StringContent(newPropJson, Encoding.UTF8, "application/json"));
        var propertyId = (await response.Content.ReadAsStringAsync()).Trim('"');


        var newListing = new
        {
            title = "Test Listing",
            description = "Test Description",
            price = 1.1,
            propertyId
        };

        var json = JsonSerializer.Serialize(newListing);

        var result = await _httpClient.PostAsync("listing", new StringContent(json, Encoding.UTF8, "application/json"));
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
