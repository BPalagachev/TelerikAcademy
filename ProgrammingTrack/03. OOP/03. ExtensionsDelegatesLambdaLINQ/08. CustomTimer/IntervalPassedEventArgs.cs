using System;

// CustomEventArgs
public class IntervalPassedEventArgs : EventArgs
{
    public uint TicksLeft { get; private set; }
    public IntervalPassedEventArgs(uint aTicksLeft)
    {
        this.TicksLeft = aTicksLeft;
    }
}
