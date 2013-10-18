using System;
using System.IO;

namespace BallInCuboid
{
    enum CellType
    {
        Slide,
        Teleport,
        Empty,
        Basket
    }

    class Cell
    {
        public CellType Type { get; private set; }
        public int DeltaWidth { get; private set; }
        public int DeltaDepth { get; private set; }

        public Cell(CellType type, int deltaWidth, int deltaDepth)
        {
            this.Type = type;
            this.DeltaWidth = deltaWidth;
            this.DeltaDepth = deltaDepth;
        }

        public Cell(CellType type)
            : this(type, 0, 0)
        {
        }
    }

    class BallInCuboid
    {
        private static Cell[, ,] cuboid;
        private static int width;
        private static int height;
        private static int depth;

        private static bool MoveBallThroughCuboid(int ballWidth, int ballHeight, int ballDepth, out int finalWidth, out int finalHeight, out int finalDepth)
        {
            finalWidth = ballWidth;
            finalHeight = ballHeight;
            finalDepth = ballDepth;

            while (ballHeight < height)
            {
                Cell currentCell = cuboid[ballWidth, ballHeight, ballDepth];

                switch (currentCell.Type)
                {
                    case CellType.Slide:
                        {
                            if (ballHeight == height - 1)
                            {
                                finalWidth = ballWidth;
                                finalHeight = ballHeight;
                                finalDepth = ballDepth;
                                return true;
                            }

                            ballWidth += currentCell.DeltaWidth;
                            ballDepth += currentCell.DeltaDepth;
                            ballHeight++;
                            break;
                        }
                    case CellType.Teleport:
                        {
                            ballWidth = currentCell.DeltaWidth;
                            ballDepth = currentCell.DeltaDepth;
                            break;
                        }
                    case CellType.Empty:
                        {
                            if (ballHeight == height - 1)
                            {
                                finalWidth = ballWidth;
                                finalHeight = ballHeight;
                                finalDepth = ballDepth;
                                return true;
                            }

                            ballHeight++;
                            break;
                        }
                    case CellType.Basket:
                        {
                            finalWidth = ballWidth;
                            finalHeight = ballHeight;
                            finalDepth = ballDepth;
                            return false;
                        }
                    default:
                        {
                            break;
                        }
                }

                if (ballWidth < 0 || ballWidth >= width || ballDepth < 0 || ballDepth >= depth)
                {
                    finalWidth = ballWidth - currentCell.DeltaWidth;
                    finalHeight = ballHeight - 1;
                    finalDepth = ballDepth - currentCell.DeltaDepth;

                    return false;
                }
            }

            finalWidth = ballWidth;
            finalHeight = ballHeight - 1;
            finalDepth = ballDepth;

            return true;
        }

        static void Main()
        {
            string inputDimensions = Console.ReadLine();
            string[] dimensions = inputDimensions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            width = Int32.Parse(dimensions[0]);
            height = Int32.Parse(dimensions[1]);
            depth = Int32.Parse(dimensions[2]);

            cuboid = new Cell[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string plane = Console.ReadLine();
                string[] rows = plane.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                for (int d = 0; d < depth; d++)
                {
                    string[] codes = rows[d].Split(new char[] { ')', '(', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int index = 0;
                    int w = 0;
                    while (index < codes.Length)
                    {
                        switch (codes[index])
                        {
                            case "S":
                                {
                                    string delta = codes[++index];
                                    int deltaWidth = 0;
                                    int deltaDepth = 0;

                                    switch (delta)
                                    {
                                        case "L":
                                            {
                                                deltaWidth = -1;
                                                deltaDepth = 0;
                                                break;
                                            }
                                        case "R":
                                            {
                                                deltaWidth = 1;
                                                deltaDepth = 0;
                                                break;
                                            }
                                        case "F":
                                            {
                                                deltaWidth = 0;
                                                deltaDepth = -1;
                                                break;
                                            }
                                        case "B":
                                            {
                                                deltaWidth = 0;
                                                deltaDepth = 1;
                                                break;
                                            }
                                        case "FL":
                                            {
                                                deltaWidth = -1;
                                                deltaDepth = -1;
                                                break;
                                            }
                                        case "FR":
                                            {
                                                deltaWidth = 1;
                                                deltaDepth = -1;
                                                break;
                                            }
                                        case "BL":
                                            {
                                                deltaWidth = -1;
                                                deltaDepth = 1;
                                                break;
                                            }
                                        case "BR":
                                            {
                                                deltaWidth = 1;
                                                deltaDepth = 1;
                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    cuboid[w, h, d] = new Cell(CellType.Slide, deltaWidth, deltaDepth);
                                    break;
                                }
                            case "E":
                                {
                                    cuboid[w, h, d] = new Cell(CellType.Empty);
                                    break;
                                }
                            case "T":
                                {
                                    int teleportWidth = Int32.Parse(codes[++index]);
                                    int teleportDepth = Int32.Parse(codes[++index]);

                                    cuboid[w, h, d] = new Cell(CellType.Teleport, teleportWidth, teleportDepth);
                                    break;
                                }
                            case "B":
                                {
                                    cuboid[w, h, d] = new Cell(CellType.Basket);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        index++;
                        w++;
                    }
                }
            }

            string ballInput = Console.ReadLine();
            string[] ballCoordinates = ballInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int initialWidth = Int32.Parse(ballCoordinates[0]);
            int initialDepth = Int32.Parse(ballCoordinates[1]);
            int initialHeight = 0;

            int finalWidth;
            int finalHeight;
            int finalDepth;

            bool hasExited = MoveBallThroughCuboid(initialWidth, initialHeight, initialDepth, out finalWidth, out finalHeight, out finalDepth);

            Console.WriteLine("{0}\n{1} {2} {3}", hasExited ? "Yes" : "No", finalWidth, finalHeight, finalDepth);
        }
    }
}
