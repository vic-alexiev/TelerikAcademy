using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCalculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ViewState["accumulator"] = 0.0;
            }
        }

        protected void ButtonDigit_Click(object sender, EventArgs e)
        {
            bool equalsPressed = Convert.ToBoolean(this.ViewState["equalsPressed"]);
            if (equalsPressed)
            {
                this.TextBoxScreen.Text = string.Empty;
                this.ViewState["equalsPressed"] = false;
            }

            double digit = double.Parse((sender as Button).Text);
            this.TextBoxScreen.Text += digit.ToString();
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.TextBoxScreen.Text = string.Empty;
        }

        protected void ButtonOperation_Click(object sender, EventArgs e)
        {
            double operand = double.Parse(this.TextBoxScreen.Text);
            this.TextBoxScreen.Text = string.Empty;

            string operation = (sender as Button).Text;

            double accumulator = Convert.ToDouble(this.ViewState["accumulator"]);
            switch (operation)
            {
                case "+":
                    {
                        accumulator += operand;
                        this.ViewState["accumulator"] = accumulator;
                        this.ViewState["operation"] = new Func<double, double, double>((x, y) => x + y);
                        break;
                    }
                case "-":
                    {
                        if (accumulator == 0.0)
                        {
                            accumulator = operand;
                            this.ViewState["accumulator"] = accumulator;
                        }

                        this.ViewState["operation"] = new Func<double, double, double>((x, y) => x - y);
                        break;
                    }
                case "*":
                    {
                        if (accumulator == 0.0)
                        {
                            accumulator = operand;
                        }
                        else
                        {
                            accumulator *= operand;
                        }

                        this.ViewState["accumulator"] = accumulator;
                        this.ViewState["operation"] = new Func<double, double, double>((x, y) => x * y);
                        break;
                    }
                case "/":
                    {
                        if (accumulator == 0.0)
                        {
                            accumulator = operand;
                        }
                        else
                        {
                            accumulator /= operand;
                        }

                        this.ViewState["accumulator"] = accumulator;
                        this.ViewState["operation"] = new Func<double, double, double>((x, y) => x / y);
                        break;
                    }
                case "√":
                    {
                        this.TextBoxScreen.Text = Math.Sqrt(operand).ToString("N4");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            double accumulator = Convert.ToDouble(this.ViewState["accumulator"]);
            Func<double, double, double> operation = this.ViewState["operation"] as Func<double, double, double>;

            accumulator = operation(accumulator, double.Parse(this.TextBoxScreen.Text));
            this.TextBoxScreen.Text = accumulator.ToString("N4");
            this.ViewState["accumulator"] = 0.0;
            this.ViewState["equalsPressed"] = true;
        }
    }
}