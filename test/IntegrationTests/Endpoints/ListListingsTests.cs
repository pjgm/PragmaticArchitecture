namespace IntegrationTests.Endpoints;

public class ListListingsTests : IClassFixture<RealEstatePortalApiFactory>
{
    private readonly HttpClient _httpClient;

    public ListListingsTests(RealEstatePortalApiFactory apiFactory)
    {
        _httpClient = apiFactory.CreateClient();
    }

    [Fact]
    public async Task ListListings_WithEmptyDatabase_ShouldReturnSuccessStatusCode()
    {
        var result = await _httpClient.GetAsync("listings");
        result.EnsureSuccessStatusCode();
    }
}
