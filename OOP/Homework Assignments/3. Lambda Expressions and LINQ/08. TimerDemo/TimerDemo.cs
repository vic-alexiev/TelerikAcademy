using System;

class TimerDemo
{
    static void Main()
    {
        int ticksCount = 10;
        int interval = 2000;
        Timer timer = new Timer(ticksCount, interval);
        timer.TimeElapsed += new TimeElapsedEventHandler(timer_TimeElapsed);

        Console.WriteLine("Timer started for {0} ticks, a tick occurring once every {1} second(s).", ticksCount, interval / 1000);

        timer.Run();
    }

    static void timer_TimeElapsed(object sender, TimeElapsedEventArgs e)
    {
        Console.WriteLine("Timer interval has elapsed! Ticks left = {0}.", e.TicksLeft);
    }
}

