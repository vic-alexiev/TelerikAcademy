using System;
using System.Threading;

class TimerDemo
{
    static void Main()
    {
        int ticksCount = 10;
        int interval = 2000; // milliseconds
        TimerElapsedDelegate timerElapsedDelegate = new TimerElapsedDelegate(PrintTicksLeft);

        Timer timer = new Timer(ticksCount, interval, timerElapsedDelegate);

        Console.WriteLine("Timer started for {0} ticks, a tick occurring once every {1} second(s).", ticksCount, interval / 1000);

        Thread timerThread = new Thread(new ThreadStart(timer.Run));
        timerThread.Start();
    }

    static void PrintTicksLeft(int ticksLeft)
    {
        Console.WriteLine("Timer interval has elapsed. Ticks left: {0}.", ticksLeft);
    }
}