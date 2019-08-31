using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogReader.models
{
    public class BlogListEntry
    {
        public BlogListEntry(string url)
        {
            Url = url;
        }
        public string Url { get; }
    }
}
