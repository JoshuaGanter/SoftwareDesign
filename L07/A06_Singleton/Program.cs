using System;
using System.Collections.Generic;

namespace A06_Singleton
{
    class Program
    {
        public static List<Person> personen = new List<Person>();

        public static void Main(string[] args)
        {
            // Eine Stelle, an der Personen angelegt werden
            new Person("Dieter", 44);
            new Person("Horst", 45);
            new Person("Walter", 33);
            new Person("Karl-Heinz", 22);

            // Eine ANDERE Stelle, an der Personen angelegt werden
            new Person("Brunhilde", 56);
            new Person("Maria", 75);
            new Person("Kunigunde", 22);
            new Person("Tusnelda", 12);

            foreach (var person in personen)
            {
                Console.WriteLine(person);
            }
        }
    }
    public class Person
    {
        public string Name;
        public int Age;
        private int Id;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Id = IdGenerator.Instance.GetNextId();
            Program.personen.Add(this);
        }

        public override string ToString()
        {
            return $"Name: {Name},  Age: {Age}, Id: {Id}";
        }
    }

    public class IdGenerator
    {
        private int LastId;
        private IdGenerator()
        {
            LastId = 1;
        }
        public int GetNextId()
        {
            return LastId++;
        }

        private static IdGenerator _instance;

        public static IdGenerator Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new IdGenerator();
                }
                return _instance;
            }
        }

    } 

}
