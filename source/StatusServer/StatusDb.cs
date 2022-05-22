using Microsoft.EntityFrameworkCore;

public class StatusDb : DbContext
{
  public StatusDb(DbContextOptions options) : base(options) { }
  public DbSet<StatusTask> StatusItems => Set<StatusTask>();
  public DbSet<Measurement> Measurements => Set<Measurement>();
  //public DbSet<StatusConfig> Configs => Set<StatusConfig>();
}