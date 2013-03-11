using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string aName, uint aAge)
            : base(aName, aAge, Sex.male)
        {
        }

        public override string MakeSomeNoise()
        {
            return "Miauuus manly!";
        }
    }
}
