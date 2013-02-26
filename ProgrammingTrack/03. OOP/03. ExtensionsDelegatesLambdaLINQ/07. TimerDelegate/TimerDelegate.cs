// Using delegates write a class Timer that has can
// execute certain method at each t seconds.

using System;
using System.Linq;

public delegate void OnEachTick(uint ticks);
public delegate void OnTimeElapsed(string saucyMessage);
class TimerDelegate
{
    // what to do after each tick
    static public void OnTicks(uint ticks)
    {
        Console.WriteLine("{0} ticks left", ticks);
    }
    // what to do when time's up
    static public void OnElapsed(string message)
    {
        Console.WriteLine(message);
    }
    static void Main()
    {
        Timer timer = new Timer(1000, 5);
        timer.OnTicks = OnTicks;
        timer.OnTimeElapsed = OnElapsed;
        timer.Run();

    }
}
public class Timer
{
    public uint Interval { get; private set; }
    public uint Ticks { get; private set; }

    public OnEachTick OnTicks;
    public OnTimeElapsed OnTimeElapsed;

    public Timer(uint aInterval, uint aTicks)
    {
        this.Interval = aInterval;
        this.Ticks = aTicks;
    }

    public void Run()
    {
        uint ticks = this.Ticks;
        Console.WriteLine("Timer Started!");
        while (ticks > 0)
        {
            System.Threading.Thread.Sleep((int)this.Interval);
            ticks--;
            OnEachTick(ticks);
        }
        OnElapsed("BOOOM!");
    }

    // Validate deegates
    private void OnEachTick(uint ticksLeft)
    {
        if (OnTicks != null)
        {
            OnTicks(ticksLeft);
        }
    }
    private void OnElapsed(string message)
    {
        if (OnTimeElapsed!=null)
        {
            OnTimeElapsed(message);
        }
    }
}
