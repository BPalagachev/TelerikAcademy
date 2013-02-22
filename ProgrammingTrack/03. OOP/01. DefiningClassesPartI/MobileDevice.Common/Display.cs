using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    public class Display
    {
        public float? Size { get; set; } // Size in inches
        public uint? NumberOfColors { get; set; }

        // task 2 - defining constructors
        public Display(float? size, uint? numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }
        public Display(float? size)
            : this(size, null)
        {
        }
        public Display(uint? numberOfColors)
            : this(null, numberOfColors)
        {
        }

        // task 4 - override ToString Method
        public override string ToString()
        {
            StringFormater.IsIndent = true;
            StringFormater.LineLength = 60;
            string title = "Display Information";
            StringBuilder constructTextRepresentation = new StringBuilder();

            constructTextRepresentation.Append(StringFormater.CenterTitle(title) + "\n\r");
            constructTextRepresentation.Append(StringFormater.FormatLine<float?>("Display Size (inch)", this.Size));
            constructTextRepresentation.Append(StringFormater.FormatLine<uint?>("Display Colors", this.NumberOfColors));
            return constructTextRepresentation.ToString();
        }
  
    }
}
