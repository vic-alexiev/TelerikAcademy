using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class Computer
    {
        private readonly int[] Positions1 = new int[] { 0, 0, 1, 0, 0, 3, 0, 0, 4, 1, 1, 4, 2, 2, 5, 3, 3, 4, 6, 6, 7, 2, 2, 4 };
        private readonly int[] Positions2 = new int[] { 1, 2, 2, 3, 6, 6, 4, 8, 8, 4, 7, 7, 5, 8, 8, 4, 5, 5, 7, 8, 8, 4, 6, 6 };
        private readonly int[] Positions3 = new int[] { 2, 1, 0, 6, 3, 0, 8, 4, 0, 7, 4, 1, 8, 5, 2, 5, 4, 3, 8, 7, 6, 6, 4, 2 };
        private readonly int[] Priorities = new int[] { 4, 0, 2, 6, 8, 1, 3, 5, 7 };

        public int TakeTurn(SquareState[] squareStates)
        {
            for (int i = 0; i < Positions1.Length; i++)
            {
                int pos1 = Positions1[i];
                int pos2 = Positions2[i];
                int pos3 = Positions3[i];

                if ((squareStates[pos1] == SquareState.Nought && squareStates[pos2] == SquareState.Nought) ||
                    (squareStates[pos1] == SquareState.Cross && squareStates[pos2] == SquareState.Cross))
                {
                    if (squareStates[pos3] == SquareState.Empty)
                    {
                        return pos3;
                    }
                }
            }

            for (int i = 0; i < Priorities.Length; i++)
            {
                int priority = Priorities[i];

                if (squareStates[priority] == SquareState.Empty)
                {
                    return priority;
                }
            }

            return -1;
        }

        public GameResult CheckResult(SquareState[] squareStates)
        {
            for (int i = 0; i < Positions1.Length; i += 3)
            {
                int pos1 = Positions1[i];
                int pos2 = Positions2[i];
                int pos3 = Positions3[i];

                if (squareStates[pos1] == SquareState.Nought &&
                    squareStates[pos2] == SquareState.Nought &&
                    squareStates[pos3] == SquareState.Nought)
                {
                    return GameResult.ComputerWins;
                }

                if (squareStates[pos1] == SquareState.Cross &&
                    squareStates[pos2] == SquareState.Cross &&
                    squareStates[pos3] == SquareState.Cross)
                {
                    return GameResult.UserWins;
                }
            }

            bool emptySquareFound = squareStates.Any(s => s == SquareState.Empty);
            if (emptySquareFound)
            {
                return GameResult.NotFinished;
            }

            return GameResult.Draw;
        }
    }
}