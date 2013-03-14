using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            #region Add some layers of ordinary blocks and a layer of exploding block in the middle

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock1 = new Block(new MatrixCoords(startRow, i));
                Block currBlock2 = new Block(new MatrixCoords(startRow + 1, i));
                Block currBlock3 = new Block(new MatrixCoords(startRow + 2, i));

                engine.AddObject(currBlock1);
                engine.AddObject(currBlock2);
                engine.AddObject(currBlock3);
            }

            for (int i = startCol; i < endCol; i++)
            {
                ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow + 3, i));

                engine.AddObject(currBlock);
            }

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock1 = new Block(new MatrixCoords(startRow + 4, i));
                Block currBlock2 = new Block(new MatrixCoords(startRow + 5, i));
                Block currBlock3 = new Block(new MatrixCoords(startRow + 6, i));

                engine.AddObject(currBlock1);
                engine.AddObject(currBlock2);
                engine.AddObject(currBlock3);
            }

            #endregion

            #region Add a layer of gift objects

            //for (int i = startCol; i < endCol; i++)
            //{
            //    GiftBlock currBlock = new GiftBlock(new MatrixCoords(startRow, i));

            //    engine.AddObject(currBlock);
            //}

            #endregion

            #region Create side walls and a ceiling

            // create side walls
            for (int i = 0; i < WorldRows; i++)
            {
                // create a block for the left wall
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                // create a block for the right wall
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));

                engine.AddObject(leftWallBlock);
                engine.AddObject(rightWallBlock);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                // create a block for the ceiling
                IndestructibleBlock ceilingBlock = new IndestructibleBlock(new MatrixCoords(0, i));

                engine.AddObject(ceilingBlock);
            }

            #endregion

            #region Add an impassable wall

            //for (int i = startRow + 1; i < WorldRows; i++)
            //{
            //    // create an impassable block
            //    ImpassableBlock impassableBlock = new ImpassableBlock(new MatrixCoords(i, 2 * WorldCols / 3 + 2));

            //    engine.AddObject(impassableBlock);
            //}

            #endregion

            #region Create an ordinary ball

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            #endregion

            #region Replace the ordinary ball with a MeteoriteBall object

            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1), 3);

            #endregion

            #region Replace the ordinary ball with an UnstoppableBall object

            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            #endregion

            engine.AddObject(theBall);

            #region Add the racket

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            #endregion

            #region Add an instance of the TrailObject class

            //TrailObject ephemera = new TrailObject(
            //    new MatrixCoords(WorldRows / 3, WorldCols / 3), new char[,] { { '@' } }, 10);

            //engine.AddObject(ephemera);

            #endregion

            #region Add a single gift

            Gift gift = new Gift(new MatrixCoords(WorldRows / 3, WorldCols / 3), new char[,] { { '@' } });

            engine.AddObject(gift);

            #endregion
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingRacketEngine gameEngine = new ShootingRacketEngine(renderer, keyboard, 150);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootWithPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
