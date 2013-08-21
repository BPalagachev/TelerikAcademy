using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    class Individual : IComparable<Individual>
    {
        public List<Point> Path { get; set; }

        public Individual(List<Point> individual)
        {
            this.Path = individual;
        }

        private double PathLength()
        {
            double path = 0.0;
            int length = this.Path.Count - 1;

            for (int i = 0; i < length; i++)
            {
                path += this.Path[i].Distance(this.Path[i + 1]);

            }
            return path;
        }


        public int CompareTo(Individual other)
        {
            return this.PathLength().CompareTo(other.PathLength());
        }
    }
}
