using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    // Task 8 - Create class Call to hold call information - date, time, phone number, duration
    public class Call
    {
        private DateTime callDateTime;
        private uint duration;
        
        public DateTime Date
        {
            get
            {
                return callDateTime.Date;
            }
        }

        public TimeSpan Time
        {
            get
            {
                return callDateTime.TimeOfDay;
            }
        }

        public string phoneNumber { get; private set; }
        public uint Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("Duration must be non-negative!");
                }
                this.duration = value;
            }
        }

        public Call(DateTime callDataTime, string phoneNumber, uint duration)
        {
            this.callDateTime = callDataTime;
            this.phoneNumber = phoneNumber;
            this.duration = duration;
        }

        public override string ToString()
        {
            StringFormater.IsIndent = false;
            StringFormater.LineLength = 40;
            string title = "Call - " + this.callDateTime ;
            StringBuilder constructTextRepresentation = new StringBuilder();

            constructTextRepresentation.Append(StringFormater.CenterTitle(title) + "\n\r");
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("number", this.phoneNumber));
            constructTextRepresentation.Append(StringFormater.FormatLine<uint>("Duration", this.duration));
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("Date", this.callDateTime.ToShortDateString()));
            constructTextRepresentation.Append(StringFormater.FormatLine<string>("Hours-Idle", this.callDateTime.ToShortTimeString()));
            return constructTextRepresentation.ToString();
        }

    }
}
