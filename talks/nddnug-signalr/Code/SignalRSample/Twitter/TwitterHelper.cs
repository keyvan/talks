using LinqToTwitter;
using System.Collections.Generic;
using System.Linq;

namespace SignalRSample.Twitter
{
    public static class TwitterHelper
    {
        public static IEnumerable<string> GetLatestTweets(string keyword)
        {
            TwitterContext twitterContext = new TwitterContext();

            IQueryable<Search> queryResults =
                from search in twitterContext.Search
                where search.Type == SearchType.Search &&
                      search.Query == keyword
                select search;

            Search searchResult = queryResults.Single();

            IEnumerable<string> results = from item in searchResult.Statuses
                          select item.Text;
            return results;
        }
    }
}