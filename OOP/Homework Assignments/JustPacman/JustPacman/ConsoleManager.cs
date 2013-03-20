using System;
using System.Threading;

namespace JustPacman
{
    public class ConsoleManager
    {
        #region Private Fields

        private const int MAZE_ROWS = 23;
        private const int MAZE_COLS = 40;

        // all the points which can be gathered in the maze
        private int maxPoints;

        private int sleepTimeout;
        private MazeObject[,] maze = new MazeObject[MAZE_ROWS, MAZE_COLS];
        private IInputDevice inputDevice;
        private Pacman pacman;
        private Ghost[] ghosts;

        // random maze cells which will be the targets for the ghosts
        private readonly Location[] routeTargets = new Location[]
        {
            new Location(21, 1),
            new Location(1, 1),
            new Location(2, 36),
            new Location(21, 36),
            new Location (10, 11),
            new Location (10, 29)
        };

        private Random targetSelector = new Random();

        #endregion

        #region Constructors

        public ConsoleManager(IInputDevice inputDevice, int sleepTimeout)
        {
            this.inputDevice = inputDevice;
            this.sleepTimeout = sleepTimeout;

            this.inputDevice.LeftArrowKeyPressed += new EventHandler(this.inputDevice_LeftArrowKeyPressed);
            this.inputDevice.RightArrowKeyPressed += new EventHandler(this.inputDevice_RightArrowKeyPressed);
            this.inputDevice.UpArrowKeyPressed += new EventHandler(this.inputDevice_UpArrowKeyPressed);
            this.inputDevice.DownArrowKeyPressed += new EventHandler(this.inputDevice_DownArrowKeyPressed);

            InitMaze();

            pacman = new Pacman(new Location(15, 18), '>', ConsoleColor.Yellow);
            pacman.ScoreUpdated += new ScoreUpdatedEventHandler(this.pacman_ScoreUpdated);
            Draw(pacman);

            IMovingStrategy strategy = new BfsStrategy();

            // Shadow, the red guy
            Ghost blinky = new Ghost(new Location(8, 18), ConsoleColor.Red, strategy);
            // Bashful, the blue guy
            Ghost inky = new Ghost(new Location(11, 16), ConsoleColor.Cyan, strategy);
            // Speedy, the pink guy
            Ghost pinky = new Ghost(new Location(11, 18), ConsoleColor.Magenta, strategy);
            // Pokey, the slow guy
            Ghost clyde = new Ghost(new Location(11, 20), ConsoleColor.Green, strategy);

            ghosts = new Ghost[4];
            ghosts[0] = blinky;
            ghosts[1] = inky;
            ghosts[2] = pinky;
            ghosts[3] = clyde;

            foreach (Ghost ghost in ghosts)
            {
                ghost.EndOfRouteReached += new EventHandler(this.ghost_EndOfRouteReached);
                ghost.CalcRoute(routeTargets[targetSelector.Next(routeTargets.Length)], maze);
            }
        }

        void ghost_EndOfRouteReached(object sender, EventArgs e)
        {
            (sender as Ghost).CalcRoute(routeTargets[targetSelector.Next(routeTargets.Length)], maze);
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            while (true)
            {
                foreach (Ghost ghost in ghosts)
                {
                    Draw(ghost);
                }

                Thread.Sleep(this.sleepTimeout);

                // all points have been gathered - Pac-Man wins
                if (pacman.Points == maxPoints)
                {
                    PrintGameOver();
                    return;
                }

                foreach (Ghost ghost in ghosts)
                {
                    RestoreCellState(ghost.Location.Row, ghost.Location.Col);
                    ghost.Move();

                    // If Pac-Man and the ghost are in the same cell, a collision occurs.
                    // If Pac-Man has lives, the ghost returns to the "monster pen".
                    // If Pac-Man has no lives, the ghost eats him and the game is over.
                    if (ghost.Location == pacman.Location)
                    {
                        if (pacman.Lives > 0)
                        {
                            pacman.Lives--;
                            ghost.Location = new Location(11, 16);
                            ghost.ClearRoute();
                        }
                        else
                        {
                            PrintGameOver();
                            return;
                        }
                    }
                }

                inputDevice.ProcessInput();
            }
        }

        #endregion

        #region Private Methods

        private void InitMaze()
        {
            ulong[] rows = new ulong[]{
                1099511627775, // row 1
                549755813889, // row 2
                755578613749, // row 3
                722259322901, // row 4
                737307960261, // row 5
                599861673969, // row 6
                962209021959, // row 7
                206154235892, // row 8
                137573203972, // row 9
                1013276651479, // row 10
                34527683408, // row 11
                1076594124895, // row 12
                45801975632, // row 13
                1007874646359, // row 14
                146767002692, // row 15
                173946175764, // row 16
                1025418198391, // row 17
                551905394945, // row 18
                803158884189, // row 19
                695784702021, // row 20
                754835258869, // row 21
                549757911041, // row 22
                1099511627775 // row 23
            };

            for (int rowIndex = 0; rowIndex < MAZE_ROWS; rowIndex++)
            {
                for (int colIndex = 0; colIndex < MAZE_COLS; colIndex++)
                {
                    maze[rowIndex, MAZE_COLS - 1 - colIndex] = new MazeObject(MazeObjectType.EmptyCell);

                    ulong mask = (ulong)1 << colIndex;
                    if ((rows[rowIndex] & mask) != (ulong)0)
                    {
                        // the bricks
                        maze[rowIndex, MAZE_COLS - 1 - colIndex] = new MazeObject(MazeObjectType.Brick);
                        Draw(rowIndex, MAZE_COLS - 1 - colIndex, '#', ConsoleColor.Blue);

                        if (rowIndex == 9 && colIndex == 22)
                        {
                            // the monster pen door
                            maze[rowIndex, MAZE_COLS - 1 - colIndex] = new MazeObject(MazeObjectType.PenDoor);
                            Draw(rowIndex, MAZE_COLS - 1 - colIndex, '=', ConsoleColor.Magenta);
                        }
                    }
                    else if (rowIndex >= 8 && rowIndex <= 15 && colIndex <= 26 && colIndex >= 16
                        || (rowIndex == 7 || rowIndex == 8 || rowIndex == 14 || rowIndex == 15)
                        && (colIndex >= MAZE_COLS - 2 || colIndex <= 1)
                        || (rowIndex == 10 || rowIndex == 12) && (colIndex >= MAZE_COLS - 4 || colIndex <= 3))
                    {
                        // these will remain empty cells
                        continue;
                    }
                    else if ((rowIndex == 2 || rowIndex == 20) && (colIndex == 1 || colIndex == 38))
                    {
                        // the power pellets (energizers)
                        maze[rowIndex, MAZE_COLS - 1 - colIndex] = new MazeObject(MazeObjectType.PowerPellet, 50);
                        Draw(rowIndex, MAZE_COLS - 1 - colIndex, '$', ConsoleColor.White);
                    }
                    else
                    {
                        // the pellets
                        maze[rowIndex, MAZE_COLS - 1 - colIndex] = new MazeObject(MazeObjectType.Pellet, 10);
                        Draw(rowIndex, MAZE_COLS - 1 - colIndex, '.', ConsoleColor.Yellow);
                    }

                    this.maxPoints += maze[rowIndex, MAZE_COLS - 1 - colIndex].Points;
                }
            }

            Console.CursorVisible = false;
        }

        private void Draw(int row, int col, char character, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(character);
        }

        private void MakeCellEmpty(int row, int col)
        {
            maze[row, col] = new MazeObject(MazeObjectType.EmptyCell);
            Draw(row, col, (char)32, ConsoleColor.Black);
        }

        private void Draw(Actor actor)
        {
            Draw(actor.Location.Row, actor.Location.Col, actor.Character, actor.Color);
        }

        private void RestoreCellState(int row, int col)
        {
            if (maze[row, col].Type == MazeObjectType.EmptyCell ||
                maze[row, col].Type == MazeObjectType.PenDoor)
            {
                Draw(row, col, (char)32, ConsoleColor.Black);
            }
            else if (maze[row, col].Type == MazeObjectType.Pellet)
            {
                Draw(row, col, '.', ConsoleColor.Yellow);
            }
            else if (maze[row, col].Type == MazeObjectType.PowerPellet)
            {
                Draw(row, col, '$', ConsoleColor.White);
            }
        }

        private bool CanMovePacman(Location direction)
        {
            Location nextLocation = pacman.Location + direction;

            if (nextLocation.Row < 0 || nextLocation.Row >= MAZE_ROWS ||
                nextLocation.Col < 0 || nextLocation.Col >= MAZE_COLS)
            {
                return false;
            }

            if (maze[nextLocation.Row, nextLocation.Col].Type == MazeObjectType.Brick)
            {
                return false;
            }
            return true;
        }

        private bool TryTeleportPacman(Location direction)
        {
            Location nextLocation = pacman.Location + direction;

            if (nextLocation.Row == 10 || nextLocation.Row == 12)
            {
                if (nextLocation.Col == MAZE_COLS)
                {
                    MakeCellEmpty(pacman.Location.Row, pacman.Location.Col);
                    pacman.Location = new Location(nextLocation.Row, 0);
                    Draw(pacman);
                    return true;
                }
                else if (nextLocation.Col == -1)
                {
                    MakeCellEmpty(pacman.Location.Row, pacman.Location.Col);
                    pacman.Location = new Location(nextLocation.Row, MAZE_COLS - 1);
                    Draw(pacman);
                    return true;
                }
            }

            return false;
        }

        private void UpdatePacmanScore()
        {
            MazeObject cell = maze[pacman.Location.Row, pacman.Location.Col];
            if (cell.Points > 0)
            {
                pacman.Points += cell.Points;

                // the power pellet gives an extra life and pacman can eat a ghost
                if (cell.Type == MazeObjectType.PowerPellet)
                {
                    pacman.Lives++;
                }
            }
        }

        private void PrintGameOver()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(16, 11);
            Console.Write("GAME");
            Console.SetCursorPosition(16, 12);
            Console.Write("OVER!");
            Console.SetCursorPosition(0, MAZE_ROWS + 1);
        }

        #region Event Handlers

        private void inputDevice_LeftArrowKeyPressed(object sender, EventArgs e)
        {
            Location toTheLeft = new Location(0, -1);
            if (CanMovePacman(toTheLeft))
            {
                MakeCellEmpty(pacman.Location.Row, pacman.Location.Col);
                pacman.UpdateLocation(toTheLeft);
                Draw(pacman);
                UpdatePacmanScore();
            }
            else
            {
                TryTeleportPacman(toTheLeft);
            }
        }

        private void inputDevice_RightArrowKeyPressed(object sender, EventArgs e)
        {
            Location toTheRight = new Location(0, 1);
            if (CanMovePacman(toTheRight))
            {
                MakeCellEmpty(pacman.Location.Row, pacman.Location.Col);
                pacman.UpdateLocation(toTheRight);
                Draw(pacman);
                UpdatePacmanScore();
            }
            else
            {
                TryTeleportPacman(toTheRight);
            }
        }

        private void inputDevice_UpArrowKeyPressed(object sender, EventArgs e)
        {
            Location up = new Location(-1, 0);
            if (CanMovePacman(up))
            {
                MakeCellEmpty(pacman.Location.Row, pacman.Location.Col);
                pacman.UpdateLocation(up);
                Draw(pacman);
                UpdatePacmanScore();
            }
        }

        private void inputDevice_DownArrowKeyPressed(object sender, EventArgs e)
        {
            Location down = new Location(1, 0);
            if (CanMovePacman(down))
            {
                MakeCellEmpty(pacman.Location.Row, pacman.Location.Col);
                pacman.UpdateLocation(down);
                Draw(pacman);
                UpdatePacmanScore();
            }
        }

        private void pacman_ScoreUpdated(object sender, ScoreUpdatedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, MAZE_ROWS);
            Console.WriteLine("POINTS: {0} LIVES: {1}", e.Score.Points, e.Score.Lives);
        }

        #endregion

        #endregion
    }
}
