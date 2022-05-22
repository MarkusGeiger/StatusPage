public class TaskService : IHostedService, IDisposable
{
  private int executionCount = 0;
  private readonly ILogger<TaskService> _logger;
  private Timer _timer = null!;

  private readonly PingTask _pingTask;

  public TaskService(ILogger<TaskService> logger)
  {
    _logger = logger;
    _pingTask = new PingTask();
  }

  public Task StartAsync(CancellationToken stoppingToken)
  {
    _logger.LogInformation("Task Service running.");

    _timer = new Timer(DoWork, null, TimeSpan.Zero,
        TimeSpan.FromSeconds(5));

    return Task.CompletedTask;
  }

  private void DoWork(object? state)
  {
    var count = Interlocked.Increment(ref executionCount);

    _logger.LogInformation(
        "Task Service is working. Count: {Count}", count);

    var task = Task.Run(async ()=> 
    {
      await _pingTask.DoWork();
    });
    task.Wait();
  }

  public Task StopAsync(CancellationToken stoppingToken)
  {
    _logger.LogInformation("Task Service is stopping.");

    _timer?.Change(Timeout.Infinite, 0);

    return Task.CompletedTask;
  }

  public void Dispose()
  {
    _timer?.Dispose();
  }
}