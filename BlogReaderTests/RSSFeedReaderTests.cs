using NUnit.Framework;
using BlogReader;
using System.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Linq;

namespace BlogReaderTests
{
    public class RSSFeedReaderTests
    {
        [Test]
        public void When_getting_feed_data_for_a_single_url()
        {
            var reader = new RSSFeedReader();
            string url = "https://martinfowler.com/feed.atom";
            SyndicationFeed feed = reader.GetFeedData(url);
            
            Assert.That(feed != null);
            Assert.That(feed.Description.Text != null);
            Assert.That(feed.Links.Count > 0);          
        }

        [Test]
        public void When_getting_feed_data_for_multiple_urls()
        {
            var reader = new RSSFeedReader();
            var urls = new List<string>() { "https://martinfowler.com/feed.atom", "https://www.codingblocks.net/podcast-feed.xml" };
            List<SyndicationItem> items = new List<SyndicationItem>();
            urls.ForEach(url =>
            {
               items.AddRange(reader.GetFeedData(url).Items.ToList<SyndicationItem>());
            });

            Assert.That(items.Count > 0);
        }
    }
}