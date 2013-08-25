using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05.StringOccurenceCounterHost.StringOccuerece;

namespace _05.StringOccurenceCounterHost
{
    class Program
    {
        static void Main(string[] args)
        {
            StringOccurenceCounterClient client = new StringOccurenceCounterClient();
            var spiroCount = client.GetData("Spiro", "SpiroSpiroSpiroSpiroSpiroSpiroSpiroSpiroSpiroSpiro");
            Console.WriteLine(spiroCount);
        }
    }
}
