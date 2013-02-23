using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [AttributeUsage(AttributeTargets.Struct |  AttributeTargets.Class 
        | AttributeTargets.Interface,  AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        public string Major { get; private set; }
        public string Minor { get; private set; }
        public VersionAttribute(string aMajor, string aMinor)
        {
            this.Major = aMajor;
            this.Minor = aMinor;
        }
    }
}
