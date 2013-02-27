using System.Threading;

public delegate void TimerElapsedDelegate(int ticks);

public class Timer
{
    private int ticksCount;
    private int interval;
    private TimerElapsedDelegate callback;

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

    public Timer(int ticksCount, int interval, TimerElapsedDelegate callback)
    {
        this.ticksCount = ticksCount;
        this.interval = interval;
        this.callback = callback;
    }

    public void Run()
    {
        int ticks = this.ticksCount;
        while (ticks > 0)
        {
            Thread.Sleep(this.interval);
            ticks--;
            this.callback(ticks);
        }
    }
}
