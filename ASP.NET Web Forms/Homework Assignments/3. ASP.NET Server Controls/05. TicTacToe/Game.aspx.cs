using System;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class Game : System.Web.UI.Page
    {
        private static Computer computer;

        static Game()
        {
            computer = new Computer();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.InitSquares();
            }
        }

        protected void Square_Click(object sender, EventArgs e)
        {
            Button clickedSquare = sender as Button;
            clickedSquare.Text = "X";
            clickedSquare.Enabled = false;

            int userIndex = int.Parse(clickedSquare.ID.Substring(clickedSquare.ID.Length - 1));

            SquareState[] squareStates = this.ViewState["SquareStates"] as SquareState[];
            squareStates[userIndex] = SquareState.Cross;

            GameResult result = computer.CheckResult(squareStates);
            if (result == GameResult.NotFinished)
            {
                int computerIndex = computer.TakeTurn(squareStates);
                if (computerIndex < 0)
                {
                    throw new ApplicationException("Computer couldn't choose a square.");
                }

                Button computerChoice = (Button)this.FindControl("Button" + computerIndex);
                squareStates[computerIndex] = SquareState.Nought;
                computerChoice.Text = "0";
                computerChoice.Enabled = false;
                result = computer.CheckResult(squareStates);
            }

            switch (result)
            {
                case GameResult.ComputerWins:
                    {
                        this.TextBoxResult.Text = "Computer wins.";
                        this.SetSquaresEnabledState(false);
                        break;
                    }
                case GameResult.UserWins:
                    {
                        this.TextBoxResult.Text = "User wins.";
                        this.SetSquaresEnabledState(false);
                        break;
                    }
                case GameResult.Draw:
                    {
                        this.TextBoxResult.Text = "Draw.";
                        this.SetSquaresEnabledState(false);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            this.InitSquares();
            this.TextBoxResult.Text = string.Empty;
        }

        private void SetSquaresEnabledState(bool enabled)
        {
            foreach (var control in this.PanelGameBoard.Controls)
            {
                if (control is Button)
                {
                    (control as Button).Enabled = enabled;
                }
            }
        }

        private void InitSquares()
        {
            foreach (var control in this.PanelGameBoard.Controls)
            {
                if (control is Button)
                {
                    (control as Button).Text = " ";
                    (control as Button).Enabled = true;
                }
            }

            this.ViewState["SquareStates"] = new SquareState[]
            {
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty,
                    SquareState.Empty
            };
        }
    }
}