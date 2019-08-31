using BlogReader.models;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;

namespace BlogReader
{
    public partial class MainForm : Form
    {
        private List<BlogListEntry> blogs = new List<BlogListEntry>();
        private List<BlogItemModel> items = new List<BlogItemModel>();
        public MainForm()
        {
            LoadBlogList();
            GetFeedData();
            InitializeComponent();

        }
        
        private void LoadBlogList()
        {
            BlogListReader reader = new BlogListReader();
            blogs = reader.LoadBlogList();
        }

        private void GetFeedData()
        {
            var feedReader = new RSSFeedReader();
            blogs.ForEach(x =>
            {
                items.AddRange(feedReader.GetFeedData(x.Url));
            });
        }
    }
}
