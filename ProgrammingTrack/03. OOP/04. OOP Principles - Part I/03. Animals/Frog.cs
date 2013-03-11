using System;

namespace _03.Animals
{
    public class Frog : Animal
    {
        public Frog(string aName, uint aAge, Sex aSex)
            : base(aName, aAge, aSex)
        {
        }

        public override string MakeSomeNoise()
        {
            return "Kvak";
        }
    }
}
