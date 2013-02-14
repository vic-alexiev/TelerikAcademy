using System;
using System.Drawing;

class Asteroid
{
    private Point location;
    public Point Location
    {
        get
        {
            return location;
        }
    }

    private char character;
    public char Character
    {
        get
        {
            return character;
        }
    }

    private ConsoleColor color;
    public ConsoleColor Color
    {
        get
        {
            return color;
        }
    }

    public Asteroid(Point location, char character, ConsoleColor color)
    {
        this.location = location;
        this.character = character;
        this.color = color;
    }

    public void UpdateLocation()
    {
        location.Y += 1;
    }
}
