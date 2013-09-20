using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoAlbum
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static Slide[] GetSlides()
        {
            string slidesFolder = AppDomain.CurrentDomain.BaseDirectory + "Images";
            DirectoryInfo directory = new DirectoryInfo(slidesFolder);

            var slides = from file in directory.GetFiles("*-small.png", SearchOption.TopDirectoryOnly)
                         orderby file.Name
                         select new Slide
                         {
                             Name = file.Name,
                             ImagePath = "Images/" + file.Name,
                             Description = "Images/" + file.Name.Replace("-small.png", string.Empty)
                         };
            return slides.ToArray();
        }
    }
}