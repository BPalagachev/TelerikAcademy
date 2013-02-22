using MobileDevice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // task - 4 - Added ToString()
            Display myDisplay = new Display(5.4f);
            Battery myBattery = new Battery("Samsung", 168, 24, BatteryType.PotatoLelom);
            GSM myGSM = new GSM("E52", "Nokia", 150m, "Jonny Bravo", myBattery, myDisplay);
            Console.WriteLine(myGSM.ToString());

            // task - 6 - Added IPhone
            GSM mySecondGSM = new GSM("E52", "Nokia", 150m);
            Console.WriteLine(mySecondGSM.ToString());
            Console.WriteLine(GSM.IPhone4S1);

            // task - 7 - Creating array of GSMs
            GSMTest.GSMTester();

            // task - 8 - Creating class to hold a call
            Call myCall = new Call(DateTime.Now, "+359 987 654 321", 300);
            Console.WriteLine(myCall.ToString());


            // task - 10
            myGSM.MakeCall("+3594309935");
            myGSM.MakeCall("+3593512102");
            List<Call> test = myGSM.CallHistory;
            foreach (var call in test)
            {
                Console.WriteLine(call.ToString());
            }
            // task - 11
            Console.WriteLine("Total Price: " + myGSM.CalculateBalance(1));

            // task - 12
            GSMCallHistoryTest.Tester();




        }
    }
}
