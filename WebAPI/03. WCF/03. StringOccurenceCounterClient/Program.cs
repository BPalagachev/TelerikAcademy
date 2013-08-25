using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace _03.StringOccurenceCounterHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri serviceAddress = new Uri("http://localhost:5555/Strings");
            ServiceHost selfHost = new ServiceHost(typeof(StringOccurenceCounter), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                System.Console.WriteLine("The service is started at endpoint " + serviceAddress);

                System.Console.WriteLine("Press [Enter] to exit.");
                System.Console.ReadLine();
            }
        }
    }
}
