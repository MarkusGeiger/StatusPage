public class StatusItem
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public bool IsOnline { get; set; }
  public IList<StatusTask> StatusTasks { get; set; }

  public StatusItem()
  {
    StatusTasks = new List<StatusTask>();
  }
}