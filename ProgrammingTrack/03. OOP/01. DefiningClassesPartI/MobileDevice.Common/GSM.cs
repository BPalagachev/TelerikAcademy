using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    public class GSM
    {
        // task 1 - Definging fields
        private string model;
        private string manufacturer;
        private decimal? price;
        private string onwer;
        Battery batery;
        Display display;
        // task 9 - creating CallHistory
        private List<Call> callHistory;
        // task 6 - Creating IPhone4s field
        private static Battery iPhone4sBattery = new Battery("Monbat - 130AH", 200, 14, BatteryType.LiIon);
        private static Display iPhone4sDisplay = new Display(3.5f, 16000000);
        private static GSM IPhone4S = new GSM("iPhone 4S - 2011", "Apple", 600, "Telerik Academy", iPhone4sBattery, iPhone4sDisplay);
        
        // task 6 - Creating IPhone4s Property
        public static GSM IPhone4S1
        {
            get { return GSM.IPhone4S; }
            set { GSM.IPhone4S = value; }
        }
        // task 5 - Encapsulation
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Model is mandatoty field. It cannot be empty or null!");
                }
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Manufacturer is mandatory field. It cannot be empty or null!");
                }
                this.manufacturer = value;
            }

        }
        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive value!");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.onwer;
            }
            set
            {
                if ((value != null) && (value.Length <= 0 || value.Length > 128))
                {
                    throw new ArgumentOutOfRangeException("Owner name must be non-empty space with maximum length of 128 symbols!");
                }
                this.onwer = value;
            }
        }
        // task 9 - Create CallHistory Propeerty
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        // task 2 - defining constructors
        public GSM(string model, string manufacturer, decimal? price, string owner, Battery batery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.batery = batery;
            this.display = display;
            callHistory = new List<Call>();
        }
        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null, null, null)
        {
        }
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }

        //task 10 - Methods Add, Delete and Clear All for CallHistory
        static private Random durationGenerator = new Random();
        public void MakeCall(string phoneNumber)
        {
            uint duration = (uint)durationGenerator.Next(750);
            Call newCall = new Call(DateTime.Now, phoneNumber, duration);
            callHistory.Add(newCall);
        }
        public void DeleteCallEntry(Call callToDelete)
        {
            callHistory.Remove(callToDelete);
        }
        public void ClearCallHistory()
        {
            callHistory.Clear();
        }
        // task 11 - Calcutate price
        public decimal CalculateBalance(decimal pricePerMinute)
        {
            uint allCallDuration = 0;
            foreach (var call in CallHistory)
            {
                allCallDuration += call.Duration;
            }
            return (allCallDuration / 60) * pricePerMinute;
        }
        // task 4 - 
        public override string ToString()
        {
            StringFormater.IsIndent = false;
            StringFormater.LineLength = 60;
            string title = "GSM Review: " + this.Manufacturer + " " + this.Model;
            StringBuilder constructTextRepresentation = new StringBuilder();

            constructTextRepresentation.Append(StringFormater.CenterTitle(title) + "\n\r");
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("Model", this.Model));
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("Manufacturer", this.Manufacturer));
            constructTextRepresentation.Append(StringFormater.FormatLine<decimal?>("Price, $", this.Price));
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("GSM Owner", this.Owner));
            if (batery == null)
            {
                constructTextRepresentation.Append(StringFormater.FormatLine<string>("Battey", "No information avaiable"));
            }
            else
            {
                constructTextRepresentation.Append(batery.ToString());
            }
            if (display == null)
            {
                constructTextRepresentation.Append(StringFormater.FormatLine<string>("Display", "No information avaiable"));
            }
            else
            {
                constructTextRepresentation.Append(display.ToString());
            }
            return constructTextRepresentation.ToString();
        }
    }
}
