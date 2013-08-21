using System;

public class HumanManager
{
    enum Gender { male, female };

    public class Human
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


    public Human BuildHuman(int age)
    {
        Human newHuman = new Human();
        newHuman.Age = age;

        if (age % 2 == 0)
        {
            newHuman.Name = "Батката";
            newHuman.Gender = Gender.male;
        }
        else
        {
            newHuman.Name = "Мацето";
            newHuman.Gender = Gender.female;
        }

        return newHuman;
    }
}