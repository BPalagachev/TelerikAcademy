using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Dog : Animal
    {
        public Dog(string aName, uint aAge, Sex aSex)
            : base(aName, aAge, aSex)
        {
        }

        public override string MakeSomeNoise()
        {
            return "Bau!";
        }
    }
}
