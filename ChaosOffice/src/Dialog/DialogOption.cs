using System;

namespace ChaosOffice
{
    public class DialogOption
    {
        public int NextLayer;
        public string Sentence;
        public Func<bool> IsSelectable = () => {return true;};
        public Action ApplyResults = () => {};
    }
}