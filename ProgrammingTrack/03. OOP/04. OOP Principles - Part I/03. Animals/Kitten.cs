using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string aName, uint aAge)
            : base(aName, aAge, Sex.female)
        {
        }

        public override string MakeSomeNoise()
        {
            return "Prrr Prrr Prr";
        }
    }
}
