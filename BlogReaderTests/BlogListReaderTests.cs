using BlogReader;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogReaderTests
{
    class BlogListReaderTests
    {
        [Test]
        public void When_loading_blog_data_from_csv_file()
        {
            BlogListReader reader = new BlogListReader();
            var list = reader.LoadBlogList();
            Assert.That(list.Count > 0);
            Assert.That(list[0].Url != null);
        }
    }
}
