using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRSample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SignalR Sample Windows Console Client";

            HubConnection connection = new HubConnection("http://localhost:50991/");

            IHubProxy hub = connection.CreateHubProxy("Echo");

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Failed to start: {0}", task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Success! Connected with client connection id {0}", connection.ConnectionId);
                    // Do more stuff here
                }
            });
            
            hub.Invoke<string>("Send", new { message = "Test" }).ContinueWith(task =>
            {
                Console.WriteLine("Value from server {0}", task.Result);
            });

            connection.Stop();

            Console.ReadLine();
        }
    }
}
