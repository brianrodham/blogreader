using System.Xml;
using System.ServiceModel.Syndication;

namespace BlogReader
{
    public interface IRSSFeedReader
    {
        SyndicationFeed GetFeedData(string url);
    }
    public class RSSFeedReader : IRSSFeedReader
    {
        public SyndicationFeed GetFeedData(string url){
            var feed = XmlReader.Create(url);
            return SyndicationFeed.Load(feed);
        }
    }
}
