using System;

/// <summary>
/// A delegate which processes the TimeElapsed event.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs e);

/// <summary>
/// A class which inherits System.EventArgs and keeps information for the ticks left
/// </summary>
public class TimeElapsedEventArgs : EventArgs
{
    private int ticksLeft;

    public int TicksLeft
    {
        get
        {
            return this.ticksLeft;
        }
    }

    public TimeElapsedEventArgs(int ticksLeft)
    {
        this.ticksLeft = ticksLeft;
    }
}