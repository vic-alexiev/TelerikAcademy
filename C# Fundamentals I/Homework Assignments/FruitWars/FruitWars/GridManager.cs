using FruitWars.Enums;
using FruitWars.Fruits;
using FruitWars.Warriors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitWars
{
    public class GridManager
    {
        private const char EmptySquareCharacter = '.';
        private const int ApplesCount = 4;
        private const int PearsCount = 3;
        private const int GridSize = 8;

        private Random _randomGenerator = new Random();
        private Square<GameObject>[,] _grid;
        private Square<Warrior>[] _warriorSquares;

        public void ArrangeGameObjects(string[] warriorCharacters)
        {
            InitGrid();

            Warrior[] warriors = GetWarriors(warriorCharacters);
            _warriorSquares = new Square<Warrior>[warriors.Length];

            HashSet<Square<GameObject>> squaresTried = new HashSet<Square<GameObject>>();
            Square<GameObject> squareToTry;
            for (int i = 0; i < warriors.Length; i++)
            {
                do
                {
                    squareToTry = _grid[
                        _randomGenerator.Next(0, GridSize),
                        _randomGenerator.Next(0, GridSize)];
                } while (
                    squaresTried.Contains(squareToTry) ||
                    IsWithin(2, squareToTry, squaresTried.Where(s => s.GameObject is Warrior)));

                squareToTry.GameObject = warriors[i];
                _warriorSquares[i] = new Square<Warrior>(squareToTry.Row, squareToTry.Col, warriors[i]);
                squaresTried.Add(squareToTry);
            }

            for (int i = 0; i < ApplesCount; i++)
            {
                do
                {
                    squareToTry = _grid[
                        _randomGenerator.Next(0, GridSize),
                        _randomGenerator.Next(0, GridSize)];
                } while (
                    squaresTried.Contains(squareToTry) ||
                    IsWithin(1, squareToTry, squaresTried.Where(s => s.GameObject is Fruit)));

                squareToTry.GameObject = new Apple();
                squaresTried.Add(squareToTry);
            }

            for (int i = 0; i < PearsCount; i++)
            {
                do
                {
                    squareToTry = _grid[
                        _randomGenerator.Next(0, GridSize),
                        _randomGenerator.Next(0, GridSize)];
                } while (
                    squaresTried.Contains(squareToTry) ||
                    IsWithin(1, squareToTry, squaresTried.Where(s => s.GameObject is Fruit)));

                squareToTry.GameObject = new Pear();
                squaresTried.Add(squareToTry);
            }
        }

        public string DisplayGrid(MoveResult moveResult = MoveResult.None)
        {
            StringBuilder result = new StringBuilder(Environment.NewLine);
            StringBuilder colNumbersBuilder = new StringBuilder();
            StringBuilder dashedLineBuilder = new StringBuilder();

            for (int col = 1; col <= _grid.GetLength(1); col++)
            {
                colNumbersBuilder.Append(" " + (col < 10 ? col : 0));
                dashedLineBuilder.Append("--");
            }

            dashedLineBuilder.Append("-");

            result.AppendLine("   " + colNumbersBuilder);
            result.AppendLine("   " + dashedLineBuilder);

            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                result.Append((row + 1) + " | ");

                for (int col = 0; col < _grid.GetLength(1); col++)
                {
                    if (_grid[row, col].GameObject == null)
                    {
                        result.Append(EmptySquareCharacter + " ");
                    }
                    else
                    {
                        Warrior warrior = _grid[row, col].GameObject as Warrior;
                        if (warrior != null)
                        {
                            result.Append((warrior.Index + 1) + " ");

                        }
                        else
                        {
                            result.Append(_grid[row, col].GameObject.Character + " ");
                        }
                    }
                }

                result.AppendLine("|");
            }

            result.AppendLine("   " + dashedLineBuilder + Environment.NewLine);

            if (moveResult == MoveResult.DrawnBattle)
            {
                result.AppendLine("DRAW!");
            }
            else if (moveResult == MoveResult.Battle)
            {
                Warrior winner = _warriorSquares.Single(ws => ws.GameObject.IsWinner).GameObject;
                result.AppendFormat(
                    "WINNER! Player {0} ({1}): {2} speed, {3} power.{4}",
                    winner.Index + 1,
                    winner.GetType().Name,
                    winner.Speed,
                    winner.Power,
                    Environment.NewLine);
            }
            else
            {
                foreach (Warrior warrior in _warriorSquares.Select(ws => ws.GameObject))
                {
                    result.AppendFormat(
                        "Player {0} ({1}): {2} speed, {3} power, {4} remaining move(s).{5}",
                        warrior.Index + 1,
                        warrior.GetType().Name,
                        warrior.Speed,
                        warrior.Power,
                        warrior.RemainingMoves,
                        Environment.NewLine);
                }
            }
            return result.ToString();
        }

        public MoveResult TryMove(Direction direction, int warriorIndex)
        {
            Square<Warrior> warriorSquare = _warriorSquares[warriorIndex];
            int newRow = warriorSquare.Row + direction.DeltaRow;
            int newCol = warriorSquare.Col + direction.DeltaCol;
            if (OutsideGrid(newRow, newCol))
            {
                return MoveResult.InvalidDirection;
            }

            _grid[warriorSquare.Row, warriorSquare.Col].GameObject = null;
            Warrior warrior = warriorSquare.GameObject;
            warrior.RemainingMoves--;

            GameObject newCellGameObject = _grid[newRow, newCol].GameObject;
            Fruit fruit = newCellGameObject as Fruit;
            if (newCellGameObject == null || fruit != null)
            {
                if (fruit != null)
                {
                    warrior.Eat(fruit);
                }
                _grid[newRow, newCol].GameObject = warrior;
                warriorSquare.Row = newRow;
                warriorSquare.Col = newCol;
                return warrior.RemainingMoves > 0 ? MoveResult.MoreMoves : MoveResult.NoMoreMoves;
            }

            Warrior otherWarrior = (Warrior)newCellGameObject;
            int clashResult = warrior.ClashWith(otherWarrior);
            if (clashResult == 0)
            {
                _grid[newRow, newCol].GameObject = new Draw();
            }
            else
            {
                Warrior winner = clashResult > 0 ? warrior : otherWarrior;
                winner.IsWinner = true;
                _grid[newRow, newCol].GameObject = winner;
            }

            warriorSquare.Row = newRow;
            warriorSquare.Col = newCol;
            return clashResult == 0 ? MoveResult.DrawnBattle : MoveResult.Battle;
        }

        public void RefreshWarriorsRemainingMoves()
        {
            foreach (Warrior warrior in _warriorSquares.Select(ws => ws.GameObject))
            {
                warrior.RefreshRemainingMoves();
            }
        }

        private void InitGrid()
        {
            _grid = new Square<GameObject>[GridSize, GridSize];

            for (int row = 0; row < _grid.GetLength(0); row++)
            {
                for (int col = 0; col < _grid.GetLength(1); col++)
                {
                    _grid[row, col] = new Square<GameObject>(row, col);
                }
            }
        }

        private Warrior[] GetWarriors(string[] warriorCharacters)
        {
            Warrior[] warriors = new Warrior[warriorCharacters.Length];
            for (int i = 0; i < warriorCharacters.Length; i++)
            {
                switch (warriorCharacters[i])
                {
                    case "t":
                        warriors[i] = new Turtle(i);
                        break;
                    case "m":
                        warriors[i] = new Monkey(i);
                        break;
                    default:
                        warriors[i] = new Pigeon(i);
                        break;
                }
            }
            return warriors;
        }

        private bool IsWithin(int movesApart, Square<GameObject> newSquare, IEnumerable<Square<GameObject>> squares)
        {
            foreach (var square in squares)
            {
                if (Math.Abs(square.Row - newSquare.Row) <= movesApart &&
                    Math.Abs(square.Col - newSquare.Col) <= movesApart)
                {
                    return true;
                }
            }
            return false;
        }

        private bool OutsideGrid(int row, int col)
        {
            return row < 0 || GridSize <= row ||
                col < 0 || GridSize <= col;
        }
    }
}