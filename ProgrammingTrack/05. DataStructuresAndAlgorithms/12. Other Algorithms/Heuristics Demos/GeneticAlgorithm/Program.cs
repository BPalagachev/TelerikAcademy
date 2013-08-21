using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    class Program
    {
        private static readonly Random random = new Random();

        static List<Point> GenerateCities()
        {

            List<Point> cities = new List<Point>();

            cities.Add(new Point(10, 10));
            cities.Add(new Point(0, 0));
            cities.Add(new Point(10, 5));
            cities.Add(new Point(2, 10));

            return cities;
        }

        static Individual GenerateRandomIndividual(List<Point> cities)
        {
            List<Point> randomPopulation = new List<Point>();
            int i = 0;
            int n = cities.Count;
            List<int> indexes = new List<int>();

            while (i < n)
            {
                int index = random.Next(0, n);
                if (indexes.Contains(index))
                {
                    continue;
                }
                else
                {
                    indexes.Add(index);

                    randomPopulation.Add(cities[index]);
                    i++;
                }
            }

            return new Individual(randomPopulation);
        }

        static void Mutation(List<Point> population)
        {
            int middle = population.Count / 2;

            Point point = population[middle - 1];
            population[middle - 1] = population[middle];
            population[middle] = point;
        }

        static List<Point> Cross(Individual firtsIndividual, Individual secondIndividual)
        {
            List<Point> newIndividual = new List<Point>();
            int n = firtsIndividual.Path.Count;
            int middle = n / 2;

            for (int i = 0; i < middle; i++)
            {
                newIndividual.Add(firtsIndividual.Path[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (!newIndividual.Contains(secondIndividual.Path[i]))
                {
                    newIndividual.Add(secondIndividual.Path[i]);
                }
            }

            return newIndividual;
        }

        static Individual CreateNewIndividual(Individual first, Individual second)
        {
            List<Point> newPopulation = new List<Point>();

            newPopulation = Cross(first, second);
            Mutation(newPopulation);

            return new Individual(newPopulation);
        }

        static List<Point> FindMinPath(List<Point> cities)
        {
            SortedSet<Individual> previousGeneration = new SortedSet<Individual>();
            int maxSteps = 100;


            for (int i = 0; i < 20; i++)
            {
                Individual path = GenerateRandomIndividual(cities);
                previousGeneration.Add(path);
            }

            for (int i = 0; i < maxSteps; i++)
            {
                SortedSet<Individual> nextGeneration = new SortedSet<Individual>();
                var bestSelection = previousGeneration.Take(20);

                foreach (Individual first in bestSelection)
                {
                    foreach (var second in bestSelection)
                    {
                        if (first != second)
                        {
                            nextGeneration.Add(CreateNewIndividual(first, second));
                        }
                    }
                }

                previousGeneration = nextGeneration;
            }

            return previousGeneration.Min.Path;
        }

        static void PrintCities(List<Point> cities)
        {
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine("{0, -4}  {1, 4}", cities[i].X, cities[i].Y);
            }
        }

        static void Main(string[] args)
        {
            List<Point> cities = GenerateCities();
            Console.WriteLine("Cities: ");
            PrintCities(cities);

            List<Point> minPath = FindMinPath(cities);

            Console.WriteLine("Min path: ");
            PrintCities(minPath);
        }
    }
}
