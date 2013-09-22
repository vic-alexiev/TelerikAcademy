using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TelerikAcademyControls
{
    public partial class LinksMenuDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Link> linksList = new List<Link>();
                linksList.Add(new Link
                {
                    Title = "bTV News",
                    Url = "http://www.btv.bg/"
                });
                linksList.Add(new Link
                {
                    Title = "Telerik Academy",
                    Url = "http://academy.telerik.com/"
                });
                linksList.Add(new Link
                {
                    Title = "Dnevnik",
                    Url = "http://www.dnevnik.bg/"
                });
                linksList.Add(new Link
                {
                    Title = "Svetlin Nakov's Blog",
                    Url = "http://www.nakov.com/"
                });

                this.LinksMenuFavourites.DataSource = linksList;
                this.LinksMenuFavourites.DataBind();

                this.LinksMenuFavourites.BackColor = Color.DodgerBlue;
                this.LinksMenuFavourites.ForeColor = Color.White;
                this.LinksMenuFavourites.Font.Name = "Arial";
                this.LinksMenuFavourites.Font.Size = FontUnit.Large;
            }
        }
    }
}