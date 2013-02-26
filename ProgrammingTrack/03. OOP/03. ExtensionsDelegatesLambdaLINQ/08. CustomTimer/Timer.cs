using System;
using System.Linq;

// This is the publisher class
public class Timer
{
    public uint Interval { get; private set; }
    public uint Ticks { get; private set; }
    public string FinishMessage { get; private set; }

    // CustomEventHandlers
    public event IntervalPassedEventHandler RaiseIntervalPassedEvent;
    public event TimeElapsedEventHandler RaiseTimerElapsedEvent;

    public Timer(uint aTicks, uint aInterval, string aFinishMessege)
    {
        this.Ticks = aTicks;
        this.Interval = aInterval;
        this.FinishMessage = aFinishMessege;
    }

    protected virtual void OnIntervalPassed(IntervalPassedEventArgs e)
    {
        // Each Time when event happens call the eventhandler with CustomEventArgs
        IntervalPassedEventHandler handler = RaiseIntervalPassedEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    protected virtual void OnTimeElapse(TimeElapsedEventArgs e)
    {
        TimeElapsedEventHandler handler = RaiseTimerElapsedEvent;
        if (handler!=null)
        {
            handler(this, e);
        }
    }

    public void StartTimer()
    {
        // Method that starts the Timer. Ticks the timer
        uint ticksLeft = this.Ticks;
        while (ticksLeft > 0)
        {
            System.Threading.Thread.Sleep((int)this.Interval);
            ticksLeft--;
            // Call the method that calls the event handler with custom arguments
            OnIntervalPassed(new IntervalPassedEventArgs(ticksLeft));
        }
        OnTimeElapse(new TimeElapsedEventArgs(this.FinishMessage));

    }

}
