using System;

namespace _02.Human
{
    public abstract class Human : IHuman
    {
        public Human(string aFirstName, string aLastName)
        {
            this.FirstName = aFirstName;
            this.LastName = aLastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
