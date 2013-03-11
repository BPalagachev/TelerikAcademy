using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization
{
    public class Person
    {
        public Person(string aName)
        {
            this.Name = aName;
        }

        public string Name { get; protected set; }
    }
}
