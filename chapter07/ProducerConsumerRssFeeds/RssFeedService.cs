using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ProducerConsumerRssFeeds
{
    public class RssFeedService
    {
        public static IEnumerable<SyndicationItem> GetFeedItems(string feedUrl)
        {
            using var xmlReader = XmlReader.Create(feedUrl);
            SyndicationFeed rssFeed = SyndicationFeed.Load(xmlReader);
            return rssFeed.Items;
        }
    }
}