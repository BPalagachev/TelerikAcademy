using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    class MyKeyValuePair : IComparable<MyKeyValuePair>
    {
        public Node Key;
        public int Value;

        public MyKeyValuePair(Node key, int value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int CompareTo(MyKeyValuePair other)
        {
            return this.Value.CompareTo(other.Value);

        }
    }
}
