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