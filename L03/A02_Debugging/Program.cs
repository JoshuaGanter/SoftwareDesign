using System;
using static System.Console;

namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Person root = Familytree.BuildTree();

            Person found = Familytree.Find(root);

            WriteLine(found);
        }
    }
}
