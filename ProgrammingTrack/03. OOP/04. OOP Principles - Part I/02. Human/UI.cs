using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Human
{
    public class UI
    {
        public static void Main(string[] args)
        {
            List<Student> listOfStudents = new List<Student>();
            listOfStudents.Add(new Student("Aaa", "Bbb", 5));
            listOfStudents.Add(new Student("Vvv", "Ggg", 6));
            listOfStudents.Add(new Student("Ddd", "Eee", 6));
            listOfStudents.Add(new Student("Jjj", "Zzz", 4));
            listOfStudents.Add(new Student("Iii", "Kkk", 5));
            listOfStudents.Add(new Student("Mmm", "Lll", 6));
            listOfStudents.Add(new Student("Nnn", "Qqq", 6));
            listOfStudents.Add(new Student("Aaa", "Ppp", 3));
            listOfStudents.Add(new Student("Rrr", "Uuu", 3));
            listOfStudents.Add(new Student("Nnn", "Bbb", 4));
            Console.WriteLine("Sorted by Grade:");
            foreach (var item in listOfStudents.OrderBy(x => x.Grade))
            {
                Console.WriteLine("{0} {1} - {2}", item.FirstName, item.LastName, item.Grade);
            }

            List<Worker> listOfWorkers = new List<Worker>();
            listOfWorkers.Add(new Worker("www", "uuu", 1000, 1));
            listOfWorkers.Add(new Worker("jjj", "Gjjjgg", 10000, 10000));
            listOfWorkers.Add(new Worker("Ddd", "Eee", 6000, 10));
            listOfWorkers.Add(new Worker("Jjj", "ghj", 15000, 30));
            listOfWorkers.Add(new Worker("aaa", "gj", 25000, 10));
            listOfWorkers.Add(new Worker("Mmm", "zxc", 7524, 3));
            listOfWorkers.Add(new Worker("aaaNnn", "[[[", 69541, 10));
            listOfWorkers.Add(new Worker("xxx", "Ppp", 5323, 19));
            listOfWorkers.Add(new Worker("Rrr", "zxc", 55984, 2212));
            listOfWorkers.Add(new Worker("Nnn", "zxczxc", 99999999, 1));
            Console.WriteLine("Sorted by hourly pay:");
            foreach (var item in listOfWorkers.OrderBy(x => x.MoneyPerHour()))
            {
                Console.WriteLine("{0} {1} - {2}", item.FirstName, item.LastName, item.MoneyPerHour());
            }

            // merge
            List<Human> people = new List<Human>();
            foreach (var item in listOfStudents)
            {
                people.Add(item);
            }

            foreach (var item in listOfWorkers)
            {
                people.Add(item);
            }

            Console.WriteLine("Sorted By FirstName, then by LastName");
            foreach (var item in people.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
            }
        }
    }
}
