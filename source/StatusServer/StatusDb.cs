using Microsoft.EntityFrameworkCore;

public class StatusDb : DbContext
{
  public StatusDb(DbContextOptions options) : base(options) { }
  public DbSet<StatusItem> StatusItems => Set<StatusItem>();
  public DbSet<StatusConfig> Configs => Set<StatusConfig>();
}