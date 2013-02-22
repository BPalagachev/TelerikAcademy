using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    // Task - 12 - Create Class GSMCallHistoryTest to test functionality
    public class GSMCallHistoryTest
    {
        public static void Tester()
        {
            Console.WriteLine("******GSMCallHistoryTest Class******");
            // Create an instance of the GSM Class
            Battery newBattery = new Battery("Rakiq", 17500, 3500, BatteryType.PotatoLelom);
            Display newDisplay = new Display(10.1f, 3);
            GSM newGSM = new GSM("Samara", "Kadilak", 300, "My self", newBattery, newDisplay);

            // Add few calls
            newGSM.MakeCall("0111 1 888 888");
            newGSM.MakeCall("0222 2 777 777");
            newGSM.MakeCall("0500 5 999 999");
            
            // Display information about calls
            foreach (var call in newGSM.CallHistory)
            {
                Console.WriteLine(call);
            }

            // Assuing price per minute of 0.37, calculate and print total price of all calls
            Console.WriteLine("Total call price: " + newGSM.CalculateBalance(0.37m));
           
            // Remove the longest call from the History and calc the price again
            Call LongestCall = new Call(DateTime.Now, "FAKE CALL!", 0);
            uint maxDuration = 0;
            foreach (var call in newGSM.CallHistory)
            {
                if (call.Duration > maxDuration)
                {
                    maxDuration = call.Duration;
                    LongestCall = call;
                }
            }
            newGSM.DeleteCallEntry(LongestCall);
            Console.WriteLine("Call with longest duration deleted!");
            Console.WriteLine("Total call price: " + newGSM.CalculateBalance(0.37m));

            // Clear all history and print it
            newGSM.ClearCallHistory();
            foreach (var call in newGSM.CallHistory)
            {
                Console.WriteLine(call);
            }
        }
    }
}
