using System;

namespace TODO
{

    class Person
    {
        public string name { get; private set; }
        public int age { get; private set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"Mein Name ist {name} und ich bin {age} Jahre alt.";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Person horst = new Person("Horst", 42);

            Person[] people = {
                horst,
                new Person("Dieter", 66),
                new Person("Karl", 32),
                new Person("Erich", 79),
                new Person("Ernst", 55)
            };

            foreach (Person person in people)
            {
                DecideIfPersonIsOld(person);
            }
        }

        private static void DecideIfPersonIsOld(Person person)
        {
            if (person.age > 40)
            {
                Console.WriteLine("Du bist alt.");
            }
            else
            {
                Console.WriteLine("On the right side of fourty.");
            }
        }
    }
}
