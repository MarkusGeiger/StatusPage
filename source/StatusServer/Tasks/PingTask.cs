using System.Net.NetworkInformation;

public class PingTask : ITaskBase
{
  private readonly Ping _ping;
  public PingTask()
  {
    _ping = new Ping();
  }
  public async Task<bool> DoWork()
  {
    var pingReply = await _ping.SendPingAsync("google.com", 1000);
    System.Console.WriteLine($"Ping status: " + pingReply.Status);
    if(pingReply.Status == IPStatus.Success)
    {
        Console.WriteLine ("\tAddress: {0}", pingReply.Address.ToString ());
        Console.WriteLine ("\tRoundTrip time: {0}", pingReply.RoundtripTime);
        Console.WriteLine ("\tTime to live: {0}", pingReply.Options?.Ttl);
        Console.WriteLine ("\tDon't fragment: {0}", pingReply.Options?.DontFragment);
        Console.WriteLine ("\tBuffer size: {0}", pingReply.Buffer.Length);
    }

    return pingReply.Status == IPStatus.Success;
  }
}