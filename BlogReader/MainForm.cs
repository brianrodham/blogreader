using BlogReader.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogReader
{
    public partial class MainForm : Form
    {
        private List<BlogListEntry> blogs = new List<BlogListEntry>();

        public MainForm()
        {
            InitializeComponent();
            LoadBlogList();
        }
        
        private void LoadBlogList()
        {
            BlogListReader reader = new BlogListReader();
            blogs = reader.LoadBlogList();
        }
    }
}
