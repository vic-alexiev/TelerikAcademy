using System;

namespace JavaScriptInjection
{
    /// <summary>
    /// Enter the following script in the textbox in IE/Mozilla/Opera (Chrome will not execute it)
    /// and the "Clicks" value is lost because the "__VIEWSTATE" element has been removed.
    /// <example>
    /// <code>
    /// <script>window.onload = function () { var viewState = document.getElementById('__VIEWSTATE');viewState.parentNode.removeChild(viewState);}</script>
    /// </code>
    /// </example>
    /// </summary>
    public partial class SampleForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            LabelInput.Text = string.Format("Your input: {0}", TextBoxInput.Text);
        }

        protected void ButtonClickMe_Click(object sender, EventArgs e)
        {
            int clicksCount = Convert.ToInt32(ViewState["Clicks"]);
            ViewState["Clicks"] = ++clicksCount;

            this.LabelClicks.Text = string.Format("<strong>{0} </strong>clicks", ViewState["Clicks"]);
        }
    }
}