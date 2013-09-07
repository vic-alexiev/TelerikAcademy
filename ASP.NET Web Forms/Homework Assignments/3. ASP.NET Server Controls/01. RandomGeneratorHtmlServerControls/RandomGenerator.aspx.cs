using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorHtmlServerControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        private Random randomGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                this.txtResult.Value = string.Empty;
                return;
            }

            int firstNumber = int.Parse(this.txtFirstNumber.Value);
            int secondNumber = int.Parse(this.txtSecondNumber.Value);

            int result = randomGenerator.Next(firstNumber, secondNumber);
            this.txtResult.Value = result.ToString();
        }
    }
}