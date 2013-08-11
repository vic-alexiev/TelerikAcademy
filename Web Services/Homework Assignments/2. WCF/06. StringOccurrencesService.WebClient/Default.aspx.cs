using StringOccurrencesService.WebClient.StringOccurrencesServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringOccurrencesService.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCountOccurrences_Click(object sender, EventArgs e)
        {
            string source = TextBoxSourceString.Text.Trim();
            string target = TextBoxTargetString.Text.Trim();

            StringOccurrencesServiceClient client = new StringOccurrencesServiceClient();
            int occurrences = client.GetOccurrencesAsync(source, target).Result;
            LabelOccurrences.Text = string.Format(
                "\"{0}\" occurs {1} time(s) in \"{2}\".",
                source,
                occurrences,
                target);
        }
    }
}