using BlogReader.models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

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
            blogs.ForEach(blog =>
            {
                items.AddRange(feedReader.GetFeedData(blog.Url));
                items.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.Updated), DateTime.Parse(y.Updated)));
                items.Reverse();
            });
        }
    }
}
