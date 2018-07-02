using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    public class Test
    {
        public Attributes attr = new Attributes(1, 2, 3, 4);
        
        public void absldk()
        {
            attr.Health = 2;
        }
    }

    public class Test2
    {
        public void test()
        {
            Test te = new Test();
            te.attr.Health = 2;
        }
    }

    public class Superclass
    {

    }

    public abstract class Lowerclass : Superclass
    {

    }


    class Person : IEquatable<Person>
    {
        public string Name;

        public bool Equals(Person other)
        {
            return true;
        }

        public static void Bla()
        {
            var p1 = new Person2();
            p1.Name = "Anne";
            var p2 = new Person2();
            p2.Name = "Anne";
            p1.Equals(p2);
        }
    }
    public class Person2
    {
        public string Name;
    }

    public enum Colors
    {
        Green,
        Gray,
        Red
    }

    public class Testerino
    {
        public void nuwea(string a, string b)
        {
            Colors colorObject;
            bool success = System.Enum.TryParse<Colors>("Green", true, out colorObject);
            Colors color = (Colors) colorObject;
            int amnt = System.Enum.GetNames(typeof(Colors)).Length;
            Person2 p2 = new Person2();
            if (p2 is Person2)
            {
                System.Console.WriteLine("Hello");
            }
        }
    }

    public class Testerino2 
    {
        private TestEventHandler _onTesting;

        public delegate void TestEventHandler(string a, string b);

        public void think()
        {
            Testerino testerino = new Testerino();
            _onTesting = testerino.nuwea;
        }

        public void test()
        {
            _onTesting("a", "b");
        }
    }
}

/*Test2 aTest = new Test2("a", (Test self, Test target) => {Console.WriteLine("Used " + self.AString + " with " + target.AString); return true;});
            aTest._onUse = (Test self, Test target) => {Console.WriteLine("Used " + self.AString + " with " + target.AString);};
            aTest.OnUse(new Test("b"));
    public class Test
    {
        public string AString {get; protected set;}
        private UseItemEventHandler _onUse;
        public Test(string a)
        {
            AString = a;
        }
        public Test(string a, UseItemEventHandler onUse) : this(a)
        {
            _onUse = onUse;
        }
        public delegate bool UseItemEventHandler(Test self, Test target);
        public void OnUse(Test target)
        {
            if (_onUse != null)
            {
                System.Console.WriteLine(_onUse(this, target).ToString());
            }
        }
    }

    class Test2 : Test
    {
        public Test2(string a) : base(a)
        {}

        public Test2(string a, UseItemEventHandler onUse) : base(a, onUse)
        {}
    }*/