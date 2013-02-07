using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRSample.Twitter
{
    [HubName("Tweet")]
    public class TweetHub : Hub
    {
        public void GetTweets(string keyword)
        {
            IEnumerable<string> tweets = TwitterHelper.GetLatestTweets("Keyvan");
            Clients.All.sendTweet();
        }
    }
}