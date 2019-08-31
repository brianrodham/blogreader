using BlogReader.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogReader
{
    interface IBlogListReader
    {

    }
    public class BlogListReader: IBlogListReader
    {
        public List<BlogListEntry> LoadBlogList()
        {
            try
            {
                using (var reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/blogList.csv"))
                {
                    List<BlogListEntry> blogList = new List<BlogListEntry>();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(',');
                        blogList.Add(new BlogListEntry(data[0]));

                    }
                    return blogList;
                }
            }
            catch (FileNotFoundException ex)
            {
                return new List<BlogListEntry>();
            }
        }
    }
}
