using NUnit.Framework;
using BlogReader;
using System.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Linq;
using BlogReader.models;

namespace BlogReaderTests
{
    public class RSSFeedReaderTests
    {
        [Test]
        public void When_getting_feed_data_for_a_single_url()
        {
            var reader = new RSSFeedReader();
            string url = "https://martinfowler.com/feed.atom";
            List<BlogItemModel> feed = reader.GetFeedData(url);

            BlogItemModel item = feed.FirstOrDefault();

            Assert.That(feed != null);
            Assert.That(item.Description != null);
            Assert.That(item.Title != null);
            Assert.That(item.Author != null);
            Assert.That(item.Link != null);
            Assert.That(item.Updated != null);
        }

        [Test]
        public void When_getting_feed_data_for_multiple_urls()
        {
            var reader = new RSSFeedReader();
            var urls = new List<string>() { "https://martinfowler.com/feed.atom", "https://www.codingblocks.net/podcast-feed.xml" };
            List<BlogItemModel> items = new List<BlogItemModel>();
            urls.ForEach(url =>
            {
               items.AddRange(reader.GetFeedData(url));
            });

            Assert.That(items.Count > 0);
        }

        [Test]
        public void When_getting_trying_to_use_non_feed_url()
        {
            var reader = new RSSFeedReader();
            var urls = new List<string>() { "https://emmersionlearning.com" };
            List<BlogItemModel> items = new List<BlogItemModel>();
            urls.ForEach(url =>
            {
                items.AddRange(reader.GetFeedData(url));
            });

            Assert.That(items.Count == 0);
        }
    }
}