using GoldenRaspberryAward.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAward.Data.Context;

public class RaspberryAwardContext : DbContext
{
    public required DbSet<Movie> Movies { get; set; }

    public RaspberryAwardContext(DbContextOptions<RaspberryAwardContext> options) : base(options) { }
}