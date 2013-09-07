using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PageLifeCycleDump
{
    public partial class PageLifeCycleDump : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit invoked" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init invoked" + "<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            Response.Write("Page_InitComplete invoked" + "<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("Page_PreLoad invoked" + "<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load invoked" + "<br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("Page_LoadComplete invoked" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page_PreRender invoked" + "<br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Write("Page_PreRenderComplete invoked" + "<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            Response.Write("Page_SaveStateComplete invoked" + "<br/>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" + "<br/>");
        }

        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Init invoked" + "<br/>");
        }

        protected void ButtonOK_Load(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Load invoked" + "<br/>");
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Click invoked" + "<br/>");
        }

        protected void ButtonOK_PreRender(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_PreRender invoked" + "<br/>");
        }

        protected void ButtonOK_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at control unload
            // Response.Write("ButtonOK_Unload invoked" + "<br/>");
        }

        protected void ButtonOK_Disposed(object sender, EventArgs e)
        {
            // Response is unavailable at control dispose
            // Response.Write("ButtonOK_Unload invoked" + "<br/>");
        }
    }
}