using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

class FallingRocks
{
    private static Stopwatch stopwatch = new Stopwatch();

    // keeps the number of the first line of asteroids
    private static readonly int asteroidInitialSpawnSize = 10;

    // after how many iterations the next line of asteroids is spawned
    private static int asteroidSpawnDelay = 5;

    // what's the maximum number of asteroids in a line
    private static int asteroidSpawnUpperLimit = 8;

    // above this limit it is (almost) impossible to play due to the number of asteroids falling
    private static readonly int asteroidSpawnMaxUpperLimit = 11;


    private static readonly int sleepTimeout = 150; // milliseconds

    private static int spaceShipXCoord = 0;

    private static readonly Random numberGenerator = new Random();
    private static char[] asteroidChars = new char[] { '^', '@', '*', '&', '+', '-', '%', '$', '#', '!', '.', ';' };
    private static List<Asteroid> asteroids = new List<Asteroid>();

    private static void RemoveScrollbars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    private static void DrawSpaceShip()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(spaceShipXCoord, Console.WindowHeight - 1);
        Console.Write("(O)");
    }

    private static void MoveSpaceShipLeft()
    {
        if (spaceShipXCoord > 0)
        {
            spaceShipXCoord--;
        }
    }

    private static void MoveSpaceShipRight()
    {
        if (spaceShipXCoord + 2 < Console.WindowWidth - 1)
        {
            spaceShipXCoord++;
        }
    }

    private static void SetSpaceShipInitialLocation()
    {
        spaceShipXCoord = Console.WindowWidth / 2;
    }

    private static void CreateAsteroid()
    {
        int x = numberGenerator.Next(Console.WindowWidth);
        int charIndex = numberGenerator.Next(asteroidChars.Length);

        // the enumeration ConsoleColor contains 16 colors, of which the first (black) is not used
        int color = numberGenerator.Next(1, 16);

        Asteroid asteroid = new Asteroid(new Point(x, 0), asteroidChars[charIndex], (ConsoleColor)color);
        asteroids.Add(asteroid);
    }

    private static void InsertAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreateAsteroid();
        }
    }

    private static void ClearAsteroids()
    {
        asteroids.Clear();
    }

    private static void DeleteAsteroidsBelowTheLine()
    {
        for (int i = asteroids.Count - 1; i >= 0; i--)
        {
            if (asteroids[i].Location.Y > Console.WindowHeight - 1)
            {
                asteroids.RemoveAt(i);
            }
        }
    }

    private static void Draw(Asteroid asteroid)
    {
        Console.SetCursorPosition(asteroid.Location.X, asteroid.Location.Y);
        Console.ForegroundColor = asteroid.Color;
        Console.Write(asteroid.Character);
    }

    private static bool UpdateAsteroidsLocation()
    {
        foreach (Asteroid asteroid in asteroids)
        {
            asteroid.UpdateLocation();
            if (asteroid.Location.Y == Console.WindowHeight && 
                asteroid.Location.X >= spaceShipXCoord && 
                asteroid.Location.X <= spaceShipXCoord + 2)
            {
                // an asteroid has hit the space ship - game over
                return false;
            }
        }

        return true;
    }

    private static void DrawAsteroids()
    {
        foreach (Asteroid asteroid in asteroids)
        {
            Draw(asteroid);
        }
    }

    private static void PrintGameOver(int secondsElapsed)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Game Over!!! Your score: {0}", secondsElapsed * 100);
    }

    static void Main()
    {
        RemoveScrollbars();
        SetSpaceShipInitialLocation();
        InsertAsteroids(asteroidInitialSpawnSize);
        DrawAsteroids();

        int spawnTrigger = 0;
        int spawnSize = 0;

        stopwatch.Start();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    MoveSpaceShipLeft();
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    MoveSpaceShipRight();
                }
            }

            spawnTrigger++;

            if (!UpdateAsteroidsLocation())
            {
                stopwatch.Stop();
                PrintGameOver(stopwatch.Elapsed.Seconds);

                // start a new game and restart the stopwatch
                Console.ReadKey();
                SetSpaceShipInitialLocation();
                ClearAsteroids();

                // increase the level of difficulty - spawn asteroids more frequently 
                // and in bigger quantities
                spawnTrigger = 0;
                if (asteroidSpawnDelay > 1)
                {
                    asteroidSpawnDelay--;                    
                }

                if (asteroidSpawnUpperLimit < asteroidSpawnMaxUpperLimit)
                {
                    asteroidSpawnUpperLimit++;
                }

                stopwatch.Restart();
            }
            else
            {
                DeleteAsteroidsBelowTheLine();
            }

            Console.Clear();
            DrawSpaceShip();
            DrawAsteroids();

            if (spawnTrigger == asteroidSpawnDelay)
            {
                spawnTrigger = 0;
                spawnSize = numberGenerator.Next(asteroidSpawnUpperLimit);
                InsertAsteroids(spawnSize);
            }

            Thread.Sleep(sleepTimeout);
        }
    }
}
