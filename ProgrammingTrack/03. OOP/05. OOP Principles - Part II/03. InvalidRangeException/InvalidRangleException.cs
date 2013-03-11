using System;

namespace _03.InvalidRangeException
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(T aStart, T aEnd, string msg)
            : base(msg + string.Format("Allowed Range: [{0} {1}]", aStart, aEnd))
        {
            this.Start = aStart;
            this.End = aEnd;
        }

        public T Start { get; protected set; }

        public T End { get; protected set; }
    }
}
