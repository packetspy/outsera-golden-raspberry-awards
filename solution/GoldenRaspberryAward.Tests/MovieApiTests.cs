using GoldenRaspberryAward.Data.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace GoldenRaspberryAward.Tests;

public class MovieApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions options;

    public MovieApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();

        options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        };
    }

    [Fact]
    public async Task GetAwardIntervals_ReturnsCorrectData()
    {
        var response = await _client.GetAsync("/api/movies/intervals");
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var awardDto = JsonSerializer.Deserialize<AwardDto>(result, options);

        Assert.NotNull(awardDto);
        Assert.NotEmpty(result);
        Assert.Contains("producer", result);
    }
}