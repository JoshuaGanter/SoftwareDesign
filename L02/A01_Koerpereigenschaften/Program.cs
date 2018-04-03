using System;
using System.Linq;

namespace A01_Koerpereigenschaften
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if enough arguments are provided.
            if (args.Length == 2)
            {
                string koerper = args[0];
                double size;

                // Check if the size is a parseable double, if so, store it in the variable size.
                if (double.TryParse(args[1], out size))
                {
                    switch (koerper)
                    {
                        case "w":
                            Console.WriteLine(GetCubeInfo(size));
                            break;
                        case "k":
                            Console.WriteLine(GetSphereInfo(size));
                            break;
                        case "o":
                            Console.WriteLine(GetOctahedronInfo(size));
                            break;
                        default:
                            Console.WriteLine("Kein gültiger Körper.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Keine gültige Kantenlänge/kein gültiger Durchmesser.");
                }
            }
            else
            {
                Console.WriteLine("Die Zahl der Argumente ist ungültig.");
            }
        }

        static double GetCubeSurface(double d)
        {
            return 6 * Math.Pow(d, 2);
        }
        static double GetCubeVolume(double d)
        {
            return Math.Pow(d, 3);
        }
        static string GetCubeInfo(double d)
        {
            return "Kubus: A=" + Math.Round(GetCubeSurface(d), 2) + " | V=" + Math.Round(GetCubeVolume(d), 2);
        }

        static double GetSphereSurface(double d)
        {
            return Math.PI * Math.Pow(d, 2);
        }
        static double GetSphereVolume(double d)
        {
            return Math.PI * Math.Pow(d, 3) / 6;
        }
        static string GetSphereInfo(double d)
        {
            return "Kugel: A=" + Math.Round(GetSphereSurface(d), 2) + " | V=" + Math.Round(GetSphereVolume(d), 2);
        }

        static double GetOctahedronSurface(double d)
        {
            return 2 * Math.Sqrt(3) * Math.Pow(d, 2);
        }
        static double GetOctahedronVolume(double d)
        {
            return Math.Sqrt(2) * Math.Pow(d, 3) / 3;
        }
        static string GetOctahedronInfo(double d)
        {
            return "Oktaeder: A=" + Math.Round(GetOctahedronSurface(d), 2) + " | V=" + Math.Round(GetOctahedronVolume(d), 2);
        }
    }
}
