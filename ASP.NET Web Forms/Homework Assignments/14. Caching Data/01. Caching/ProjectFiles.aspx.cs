using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Caching
{
    public partial class ProjectFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rootPath = MapPath("~/");

            DirectoryInfo rootDirectory = new DirectoryInfo(rootPath);

            var files = rootDirectory.GetFiles();
            int filesCount = files.Length;

            this.ListViewFiles.DataSource = files;
            this.ListViewFiles.DataBind();

            if (Cache["FilesCount"] == null)
            {
                var dependency = new CacheDependency(rootPath);
                Cache.Insert(
                    "FilesCount", // key
                    filesCount, // object
                    dependency, // dependencies
                    DateTime.Now.AddHours(1), // absolute expiration
                    TimeSpan.Zero, // sliding expiration
                    CacheItemPriority.Default, // priority
                    null); // callback delegate
            }

            this.LiteralRootDirectory.Text = string.Format(
                "Root directory: {0} ({1} files)",
                rootPath,
                Cache["FilesCount"]);
        }
    }
}