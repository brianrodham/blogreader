using System.Xml;
using System.ServiceModel.Syndication;
using BlogReader.models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BlogReader
{
    public interface IRSSFeedReader
    {
        List<BlogItemModel> GetFeedData(string url);
    }
    public class RSSFeedReader : IRSSFeedReader
    {
        public List<BlogItemModel> GetFeedData(string url){
            var items = new List<BlogItemModel>();
            try
            {
                var feed = XmlReader.Create(url);
                var data = SyndicationFeed.Load(feed);

                string authors = "";

                foreach (SyndicationPerson author in data.Authors)
                {
                    authors += author.Name;
                }

                foreach (SyndicationItem item in data.Items)
                {
                    items.Add(new BlogItemModel
                    {
                        Title = item.Title.Text,
                        Author = authors,
                        Description = (item.Summary != null) ? item.Summary.Text : "",
                        Link = item.Links[0].Uri.ToString(),
                        Updated = GetDate(item)
                    });
                }
            }
            catch(Exception ex)
            {
                // Failed to parse. 
            }

            return items;
        }

        private string GetDate(SyndicationItem item)
        {
            if (DateTimeOffset.Compare(item.PublishDate, item.LastUpdatedTime) <= 0) {
                return item.LastUpdatedTime.ToString();
            }
        return item.LastUpdatedTime.ToString();
        }
    }
}
