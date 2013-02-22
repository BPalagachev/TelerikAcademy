using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    public class Battery
    {
        // task 1 - defing fields
        private string model;
        private uint? hoursIdle;
        private uint? hoursTalk;
        // task 3 - Field BatteryType created and added in the constructors
        private BatteryType type;

        // task 5
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Model is mandatoty field and it cannot be empty or null!");
                }
                this.model = value;
            }
        }
        public uint? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            private set
            {
                if (value.Value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Idle hours must be a non-negative!");
                }
                this.hoursIdle = value;
            }
        }
        public uint? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            private set
            {
                if (value.Value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Talk Hours myst be a non-negative!");
                }
                this.hoursTalk = value;
            }
        }
        public BatteryType Type { get; private set; }

        // task 2 - defining constructors
        public Battery(string model, uint? hoursIdle, uint? hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.type = type;
        }
        public Battery(string model, BatteryType type)
            : this(model, null, null, type)
        {
        }

        // task 4 - Overrinding ToSting method
        public override string ToString()
        {
            StringFormater.IsIndent = true;
            StringFormater.LineLength = 60;
            string title = "Battery Information";
            StringBuilder constructTextRepresentation = new StringBuilder();

            constructTextRepresentation.Append(StringFormater.CenterTitle(title) + "\n\r");
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("Model", this.Model));
            constructTextRepresentation.Append(StringFormater.FormatLine<BatteryType>("Battery Type", this.Type));
            constructTextRepresentation.Append(StringFormater.FormatLine<uint?>("Hours-Talk", this.HoursIdle));
            constructTextRepresentation.Append(StringFormater.FormatLine<uint?>("Hours-Idle", this.HoursTalk));
            return constructTextRepresentation.ToString();

        }
    }
}
