namespace IntegrationTests.Endpoints.Properties;

public class ListPropertiesTests(RealEstatePortalApiFactory apiFactory) : IClassFixture<RealEstatePortalApiFactory>
{
    private readonly HttpClient _httpClient = apiFactory.CreateClient();

    [Fact]
    public async Task ListProperties_WithEmptyDatabase_ShouldReturnSuccessStatusCode()
    {
        var result = await _httpClient.GetAsync("properties");
        result.EnsureSuccessStatusCode();
    }
}
