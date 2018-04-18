using System;
using System.Linq;

namespace A01_Zufallsgedicht
{
    class Program
    {
        // Literal initialization of subjects, verbs, objects.
        static string[] Subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] Verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] Objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };

        static Random Random = new Random();

        static void Main(string[] args)
        {
            int poemLength = (new int[] {Subjects.Length, Verbs.Length, Objects.Length}).Min();
            string[] poem = new string[poemLength];
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
            string verseSubject = Subjects[Random.Next(Subjects.Length - 1)];

            // Remove the subject from the subjects array by constructing a new array with the subjects not equal to the subject used.
            Subjects = Subjects.Where(val => val != verseSubject).ToArray();

            // Repeat for verbs and objects.
            string verseVerb = Verbs[Random.Next(Verbs.Length - 1)];
            Verbs = Verbs.Where(val => val != verseVerb).ToArray();

            string verseObject = Objects[Random.Next(Objects.Length - 1)];
            Objects = Objects.Where(val => val != verseObject).ToArray();
            
            return verseSubject + " " + verseVerb + " " + verseObject;
        }
    }
}
