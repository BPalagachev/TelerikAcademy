using System;

namespace _03.Animals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Animal[] animals = new Animal[]
            {
                new Dog("Rabmo", 10, Sex.male),
                new Frog("Lamqta Spaska", 4, Sex.female)
            };

            foreach (Animal animal in animals)
            {
                Console.WriteLine("{0} says \"{1}\" - {2} years old, {3} ", animal.Name, animal.MakeSomeNoise(), animal.Age, animal.Sex);
            }

            Cat[] cats = new Cat[]
            {
                new Kitten("Sexi Banowa", 18),
                new Tomcat("Jonny Bravo", 20),
            };

            foreach (Animal animal in cats)
            {
                Console.WriteLine("{0} says \"{1}\" - {2} years old, {3} ", animal.Name, animal.MakeSomeNoise(), animal.Age, animal.Sex);
            }

            Console.WriteLine("Average Age of the animals: {0}", Animal.AverageAge(animals));
            Console.WriteLine("Average Age of the cats: {0}", Animal.AverageAge(cats));
        }
    }
}
