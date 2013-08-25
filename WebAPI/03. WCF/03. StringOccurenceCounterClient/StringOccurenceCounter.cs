using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.StringOccurenceCounterHost
{
    public class StringOccurenceCounter : IStringOccurenceCounter
    {
        public int GetData(string toBeMatched, string toCountFrom)
        {
            int count = Regex.Matches(toCountFrom, toBeMatched).Count;
            return count;
        }
    }
}