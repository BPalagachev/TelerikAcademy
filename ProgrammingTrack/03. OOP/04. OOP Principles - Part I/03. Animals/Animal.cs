using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Animals
{
    public abstract class Animal : ISound
    {
        public Animal()
        {
        }

        public Animal(string aName, uint aAge, Sex aSex)
        {
            this.Name = aName;
            this.Age = aAge;
            this.Sex = aSex;
        }

        public string Name { get; private set; }

        public uint Age { get; private set; }

        public Sex Sex { get; private set; }

        public static double AverageAge(IEnumerable<Animal> arrayOfAnimals)
        {
            double age = 0;
            int counter = 0;
            foreach (var animal in arrayOfAnimals)
            {
                counter++;
                age += animal.Age;
            }

            return age / counter;
        }

        public abstract string MakeSomeNoise();
    }
}
