using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;

namespace IntegrationTests.Endpoints.Properties;

public class CreatePropertyTests : IClassFixture<RealEstatePortalApiFactory>
{
    private readonly HttpClient _httpClient;

    public CreatePropertyTests(RealEstatePortalApiFactory apiFactory)
    {
        _httpClient = apiFactory.CreateClient();
    }

    [Fact]
    public async Task CreateProperty_WithValidInput_ShouldCreateProperty()
    {
        var newProperty = new
        {
            rooms = 3,
            area = 100.12,
            floors = 1
        };

        var json = JsonSerializer.Serialize(newProperty);

        var result = await _httpClient.PostAsync("property", new StringContent(json, Encoding.UTF8, "application/json"));
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
