namespace IntegrationTests.Endpoints.Listings;

public class ListListingsTests(RealEstatePortalApiFactory apiFactory) : IClassFixture<RealEstatePortalApiFactory>
{
    private readonly HttpClient _httpClient = apiFactory.CreateClient();

    [Fact]
    public async Task ListListings_WithEmptyDatabase_ShouldReturnSuccessStatusCode()
    {
        var result = await _httpClient.GetAsync("listings");
        result.EnsureSuccessStatusCode();
    }
}
