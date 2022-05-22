public class Measurement
{
  public int Id { get; set; }
  public DateTime Timestamp { get; set; }
  public string Type { get; set; } = string.Empty;
  public bool IsOnline { get; set; }
  public StatusTask TargetTask { get; set; }
  public Measurement() 
  {
    TargetTask = new StatusTask();
  }

  public Measurement(StatusTask targetTask)
  {
    TargetTask = targetTask;
  }
}