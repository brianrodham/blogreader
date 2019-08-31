using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogReader.models
{
    public class BlogItemModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Updated { get; set; }
    }
}
