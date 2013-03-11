using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public abstract class Cat : Animal
    {
        public Cat(string aName, uint aAge, Sex aSex)
            : base(aName, aAge, aSex)
        {
        }
    }
}
