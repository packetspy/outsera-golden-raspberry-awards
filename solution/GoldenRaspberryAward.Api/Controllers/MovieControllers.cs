using GoldenRaspberryAward.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberryAward.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService service)
    {
        _movieService = service;
    }

    [HttpGet("intervals")]
    public async Task<IActionResult> GetAwardIntervals()
    {
        var result = await _movieService.GetAwardIntervals();
        return Ok(result);
    }
}