using Microsoft.EntityFrameworkCore;
using NorbitsChallenge.Models.Db;

namespace NorbitsChallenge.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // Specify the path of the database here
        optionsBuilder.UseSqlite("Filename=./NorbitsChallengeDb.sqlite");
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Settings> Settings { get; set; }
}