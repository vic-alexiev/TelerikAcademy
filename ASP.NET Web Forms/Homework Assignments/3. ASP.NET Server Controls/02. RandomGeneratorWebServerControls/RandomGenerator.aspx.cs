using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorWebServerControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        private Random randomGenerator = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                this.TextBoxResult.Text = string.Empty;
                return;
            }

            int firstNumber = int.Parse(this.TextBoxFirstNumber.Text);
            int secondNumber = int.Parse(this.TextBoxSecondNumber.Text);

            int result = randomGenerator.Next(firstNumber, secondNumber);
            this.TextBoxResult.Text = result.ToString();
        }
    }
}