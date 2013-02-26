using System;

class Subscriber
{
    // those methods are assigned for events in Timer class
    private static void Timer_HandleIntervalPassedEvent(object sender, IntervalPassedEventArgs e)
    {
        Console.WriteLine("{0} ticks left", e.TicksLeft);
    }
    private static void Timer_SayIntervalPassedEvent(object sender, IntervalPassedEventArgs e)
    {
        Console.WriteLine("Second Handler has been added!");
    }
    private static void Timer_HandleTimeElapsedEvent(object sender, TimeElapsedEventArgs e)
    {
        Console.WriteLine("Your Finish Messege: {0}", e.Messege.ToLower());
    }
    static void Main(string[] args)
    {
        Timer timer = new Timer(10, 1000, "Time's UP!");
        timer.RaiseIntervalPassedEvent += new IntervalPassedEventHandler(Timer_HandleIntervalPassedEvent);
        timer.RaiseIntervalPassedEvent += Timer_SayIntervalPassedEvent;
        timer.RaiseTimerElapsedEvent += Timer_HandleTimeElapsedEvent;
        timer.StartTimer();
    }
}
