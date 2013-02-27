using System.Threading;

public class Timer
{
    // The event that will be raised when time elapses
    public event TimeElapsedEventHandler TimeElapsed;

    private int ticksCount;
    private int interval;

    public int TicksCount
    {
        get
        {
            return this.ticksCount;
        }
    }

    public int Interval
    {
        get
        {
            return this.interval;
        }
    }

    public Timer(int ticksCount, int interval)
    {
        this.ticksCount = ticksCount;
        this.interval = interval;
    }

    /// <summary>
    /// The method which raises the event.
    /// </summary>
    /// <param name="ticks"></param>
    protected void OnTimeElapsed(int ticks)
    {
        if (TimeElapsed != null)
        {
            TimeElapsedEventArgs e = new TimeElapsedEventArgs(ticks);
            TimeElapsed(this, e);
        }
    }

    public void Run()
    {
        int ticks = this.ticksCount;
        while (ticks > 0)
        {
            Thread.Sleep(this.interval);
            ticks--;
            OnTimeElapsed(ticks);
        }
    }
}