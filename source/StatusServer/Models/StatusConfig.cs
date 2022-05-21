public class StatusConfig
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string IP { get; set; } = string.Empty;
  public IList<StatusTask> TaskConfigurations { get; set; }
  public StatusConfig()
  {
    TaskConfigurations = new List<StatusTask>();
  }
}