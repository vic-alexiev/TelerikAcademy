using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.GetSumWebForms
{
    public partial class GetSum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            double firstNumber;
            double secondNumber;

            this.ClearData();

            if (!double.TryParse(this.TextBoxFirstNumber.Text, out firstNumber))
            {
                this.LabelError.Text = "First number should be a real number.";
                return;
            }

            if (!double.TryParse(this.TextBoxSecondNumber.Text, out secondNumber))
            {
                this.LabelError.Text = "Second number should be a real number.";
                return;
            }

            double result = firstNumber + secondNumber;

            this.TextBoxResult.Text = result.ToString("N4");
        }

        private void ClearData()
        {
            this.LabelError.Text = string.Empty;
            this.TextBoxResult.Text = string.Empty;
        }
    }
}