using GameCollection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameCollectionApi.Data;

public class GameCollectionDbContext : DbContext
{
    public DbSet<GameModel> Games { get; set; }
    public GameCollectionDbContext(DbContextOptions<GameCollectionDbContext> ops) : base(ops)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("CONNECTION_STRING"));
    }
}

public class GameCollectionDbContextDesignTime : IDesignTimeDbContextFactory<GameCollectionDbContext>
{
    
    public GameCollectionDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<GameCollectionDbContext>();
        builder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        return new GameCollectionDbContext(builder.Options);
    }
}