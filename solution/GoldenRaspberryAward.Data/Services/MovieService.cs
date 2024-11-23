using GoldenRaspberryAward.Data.Context;
using GoldenRaspberryAward.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAward.Data.Services;

public class MovieService : IMovieService
{
    private readonly RaspberryAwardContext _context;

    public MovieService(RaspberryAwardContext context)
    {
        _context = context;
    }

    public async Task<AwardDto> GetAwardIntervals()
    {
        // Group winners by producer and order their wins
        var producersWithWins = _context.Movies
            .AsNoTracking()
            .Where(m => m.IsWinner)
            .GroupBy(m => m.Producer)
            .Select(group => new
            {
                Producer = group.Key,
                WinYears = group.OrderBy(m => m.Year).Select(m => m.Year).ToList()
            })
            .AsEnumerable()
            .Where(g => g.WinYears.Count() > 1) //Only include producers with multiple wins
            .ToList();

        if (!producersWithWins.Any())
            throw new InvalidOperationException("No producers with multiple awards found.");

        // Calculate intervals for each producer
        var intervals = producersWithWins.SelectMany(p =>
            p.WinYears.Zip(p.WinYears.Skip(1), (previous, next) => new ProducerIntervalDto
            {
                Producer = p.Producer,
                Interval = next - previous,
                PreviousWin = previous,
                FollowingWin = next
            })
        ).ToList();

        var minInterval = intervals.Min(i => i.Interval);
        var maxInterval = intervals.Max(i => i.Interval);

        return new AwardDto
        {
            Min = intervals.Where(i => i.Interval == minInterval).ToList(),
            Max = intervals.Where(i => i.Interval == maxInterval).ToList()
        };
    }
}