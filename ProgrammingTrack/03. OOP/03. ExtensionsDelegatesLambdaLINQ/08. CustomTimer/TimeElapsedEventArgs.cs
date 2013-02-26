using System;

// CustomEventArgs
public class TimeElapsedEventArgs : EventArgs
{
    public string Messege { get; private set; }

    public TimeElapsedEventArgs(string aMessege)
    {
        this.Messege = aMessege;
    }
}