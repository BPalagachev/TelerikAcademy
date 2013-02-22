using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    public class GSMTest
    {
        private static GSM[] gsmCollection;

        static public void GSMTester()
        {
            Console.WriteLine("*****GSMTest Class*****");
            gsmCollection = new GSM[3];
            gsmCollection[0] = new GSM("E 52", "Nokia");
            gsmCollection[1] = new GSM("Old Phone", "Mobifon", 150);
            gsmCollection[2] = new GSM("Supra", "Toyo", 12500);

            foreach (var phone in gsmCollection)
            {
                Console.WriteLine(phone);
            }
        }
    }
}
