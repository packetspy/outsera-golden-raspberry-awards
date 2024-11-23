using GoldenRaspberryAward.Data.Context;
using GoldenRaspberryAward.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAward.Data.Services;

public interface IMovieService
{
    public Task<AwardDto> GetAwardIntervals();
}