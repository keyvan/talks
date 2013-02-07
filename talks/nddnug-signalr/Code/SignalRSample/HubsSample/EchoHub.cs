using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRSample.HubsSample
{
    [HubName("Echo")]
    public class EchoHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.echoMessage(message);
        }
    }
}