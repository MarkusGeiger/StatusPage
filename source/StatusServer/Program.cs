using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => 
  options.AddDefaultPolicy(builder => 
    builder
      .AllowAnyOrigin()
      //.WithOrigins("http://localhost:3000")
      .AllowAnyMethod()
      .AllowAnyHeader()));

var connectionString = builder.Configuration.GetConnectionString("Status") ?? "Data Source=Status.db";
builder.Services.AddSqlite<StatusDb>(connectionString);
builder.Services.AddHostedService<TaskService>();

var app = builder.Build();
app.UseCors();


app.MapPost("/api/initdb", async (StatusDb db) => {
  db.StatusItems.AddRange(new List<StatusTask>
  {
    new StatusTask { Name="Test1", IsOnline = true, IpAddress = System.Net.IPAddress.Parse("192.168.2.1"), Interval = TimeSpan.FromMinutes(15), Tasks = new Dictionary<string, bool>{{"PingTask", true}, {"TelegrafTask", true}} },
    new StatusTask { Name="Test2", IsOnline = true, IpAddress = System.Net.IPAddress.Parse("192.168.1.1"), Interval = TimeSpan.FromMinutes(5), Tasks = new Dictionary<string, bool>{{"PingTask", true}, {"TelegrafTask", false}} }
  });

  // db.Configs.AddRange(new List<StatusConfig>
  // {
  //   new StatusConfig {Name = "Test1", IP = "127.0.0.1", TaskConfigurations = new List<StatusTask> { new StatusTask{Name = "Ping"}}},
  //   new StatusConfig {Name = "Test2", IP = "127.0.0.1", TaskConfigurations = new List<StatusTask> { new StatusTask{Name = "Ping"}, new StatusTask {Name = "Process"}}}
  // });

  await db.SaveChangesAsync();
});

app.MapGet("/", () => "Hello World!");
//app.MapGet("/init", async (StatusDb db) => {
//  db.Configs.AddRange(config);
//  await db.SaveChangesAsync();
//  db.StatusItems.AddRange(status);
//  await db.SaveChangesAsync();
//});
//app.MapGet("/api/config", async (StatusDb db) => await db.Configs.ToListAsync());
app.MapGet("/api/status", async (StatusDb db) => await db.StatusItems.ToListAsync());

app.Run();
