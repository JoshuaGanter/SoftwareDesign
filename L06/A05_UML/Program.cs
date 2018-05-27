using System;
using System.Collections.Generic;

namespace A05_UML
{
    class Program
    {
        static void Main(string[] args)
        {
            // We do nothing here..
        }
    }

    class Person
    {
        public string Name;
        public int Alter;
    }

    class Teilnehmer : Person
    {
        public int Matrikelnummer;
        public List<Kurs> Kurse;
    }

    class Dozent : Person
    {
        public string BueroNr;
        public string Sprechstunde;
        public List<Kurs> Kurse;

        public void GehalteneKurse()
        {
            Console.WriteLine("Ich unterrichte: ");
            foreach(var kurs in Kurse)
            {
                Console.WriteLine("- " + kurs);
            }
        }
        public List<Teilnehmer> AlleTeilnehmer()
        {
            var teilnehmer = new List<Teilnehmer>();
            foreach(var kurs in Kurse)
            {
                // Obviously, we need to check for doubles here..
                teilnehmer.AddRange(kurs.Teilnehmer);
            }
            return teilnehmer;
        }
    }

    class Kurs
    {
        public string Titel;
        public string Termin;
        public string RaumNr;
        public Dozent Dozent;
        public List<Teilnehmer> Teilnehmer;

        public string Infotext()
        {
            return "Die Veranstaltung '" + Titel + "' von Dozent/in " + Dozent.Name + " findet am " + Termin + " im Raum " + RaumNr + " statt.";
        }

        public override string ToString()
        {
            return Titel;
        }
    }
}
