using System.Net;

public class StatusTask 
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public IPAddress IpAddress { get; set; } = IPAddress.Loopback;
  public TimeSpan Interval { get; set; }
  public bool IsOnline { get; set; }
  public Dictionary<string, bool> Tasks { get; set; } = new Dictionary<string, bool>();
}