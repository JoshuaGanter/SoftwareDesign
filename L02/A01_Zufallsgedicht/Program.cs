using System;
using System.Linq;

namespace A01_Zufallsgedicht
{
    class Program
    {
        // Literal initialization of subjects, verbs, objects. The arrays must contain more items than poem_length.
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };

        static uint poem_length = 5;

        static Random random = new Random();

        static void Main(string[] args)
        {
            string[] poem = new string[poem_length];
            for (int i = 0; i < poem.Length; i++)
            {
                poem[i] = GetVerse();
            }
            
            foreach (string line in poem)
            {
                Console.WriteLine(line);
            }
        }

        static string GetVerse()
        {
            // Get a random subject.
            string verse_subject = subjects[random.Next(subjects.Length - 1)];

            // Remove the subject from the subjects list by constructing a new array with the subjects not equal to the subject used.
            subjects = subjects.Where(val => val != verse_subject).ToArray();

            // Repeat for verbs and objects.
            string verse_verb = verbs[random.Next(verbs.Length - 1)];
            verbs = verbs.Where(val => val != verse_verb).ToArray();

            string verse_object = objects[random.Next(objects.Length - 1)];
            objects = objects.Where(val => val != verse_object).ToArray();
            
            return verse_subject + " " + verse_verb + " " + verse_object;
        }
    }
}
