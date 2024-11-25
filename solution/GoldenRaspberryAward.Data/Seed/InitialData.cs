using GoldenRaspberryAward.Data.Context;
using GoldenRaspberryAward.Data.Entities;

namespace GoldenRaspberryAward.Data.Seed;

public static class InitialData
{
    public static void Load(RaspberryAwardContext context, string csvFilePath)
    {
        if (context.Movies.Any()) return;

        var lines = File.ReadAllLines(csvFilePath).Skip(1);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var columns = line.Split(';');

            var year = int.Parse(columns[0]);
            var title = columns[1];
            var studio = columns[2];
            var producers = SplitProducers(columns[3]);
            var isWinner = columns[4].Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

            foreach (var producer in producers)
            {
                context.Movies.Add(new Movie
                {
                    Year = year,
                    Title = title,
                    Studio = studio,
                    Producer = producer.Trim(),
                    IsWinner = isWinner
                });
            }
        }

        context.SaveChanges();
    }

    private static List<string> SplitProducers(string producers)
    {
        var splitBy = new[] { ",", "and" };
        return producers.Split(splitBy, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => p.Trim())
                        .ToList();
    }
}
