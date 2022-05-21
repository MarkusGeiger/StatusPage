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

var app = builder.Build();
app.UseCors();

var status = new List<StatusItem>
{
  new StatusItem { Name="Test1", IsOnline = true, StatusTasks = new List<StatusTask> { new StatusTask { Name = "State1", Status = true }, new StatusTask { Name = "State2", Status = false } }},
  new StatusItem { Name="Test2", IsOnline = true, StatusTasks = new List<StatusTask> { new StatusTask { Name = "State1", Status = true }, new StatusTask { Name = "State2", Status = true } }}
};

var config = new List<StatusConfig>
{
  new StatusConfig {Name = "Test1", IP = "127.0.0.1", TaskConfigurations = new List<StatusTask> { new StatusTask{Name = "Ping"}}},
  new StatusConfig {Name = "Test2", IP = "127.0.0.1", TaskConfigurations = new List<StatusTask> { new StatusTask{Name = "Ping"}, new StatusTask {Name = "Process"}}}
};

app.MapGet("/", () => "Hello World!");
//app.MapGet("/init", async (StatusDb db) => {
//  db.Configs.AddRange(config);
//  await db.SaveChangesAsync();
//  db.StatusItems.AddRange(status);
//  await db.SaveChangesAsync();
//});
app.MapGet("/api/config", async (StatusDb db) => await db.Configs.ToListAsync());
app.MapGet("/api/status", async (StatusDb db) => await db.StatusItems.ToListAsync());

app.Run();
