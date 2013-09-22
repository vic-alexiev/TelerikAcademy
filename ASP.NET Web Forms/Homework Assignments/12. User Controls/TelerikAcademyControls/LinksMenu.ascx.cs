using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TelerikAcademyControls
{
    public partial class LinksMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public FontInfo Font
        {
            get
            {
                return this.DataListLinksMenu.Font;
            }
        }

        public Color ForeColor
        {
            get
            {
                return this.DataListLinksMenu.ForeColor;
            }

            set
            {
                this.DataListLinksMenu.ForeColor = value;
                this.SetLinksForeColor(value, this.DataListLinksMenu);
            }
        }

        public Color BackColor
        {
            get
            {
                return this.DataListLinksMenu.BackColor;
            }

            set
            {
                this.DataListLinksMenu.BackColor = value;
            }
        }

        public ICollection<Link> DataSource
        {
            set
            {
                this.DataListLinksMenu.DataSource = value;
            }
        }

        private void SetLinksForeColor(Color color, DataList dataList)
        {
            foreach (DataListItem item in dataList.Items)
            {
                HyperLink link = item.FindControl("HyperLinkMenuItem") as HyperLink;
                if (link != null)
                {
                    link.ForeColor = color;
                }
            }
        }
    }
}