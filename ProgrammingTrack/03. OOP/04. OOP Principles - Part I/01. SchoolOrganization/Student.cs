using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization
{
    public class Student : Person, ICommentable
    {
        public Student(string aName, char aUniqueClassNumber)
            : base(aName)
        {
            this.UniqueClassNumber = aUniqueClassNumber;
        }

        public char UniqueClassNumber { get; private set; }

        public string Comments { get; set; }
    }
}
