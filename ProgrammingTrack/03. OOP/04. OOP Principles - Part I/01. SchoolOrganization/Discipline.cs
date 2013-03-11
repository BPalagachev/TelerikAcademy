using System;

namespace SchoolOrganization
{
    public class Discipline
    {
        public Discipline(string aName, uint aNumberOfLectures, uint aNumberOfExercises)
        {
            this.Name = aName;
            this.NumberOfLectures = aNumberOfLectures;
            this.NumberOfExercises = aNumberOfExercises;
        }

        public string Name { get; private set; }

        public uint NumberOfLectures { get; private set; }

        public uint NumberOfExercises { get; private set; }
    }
}
