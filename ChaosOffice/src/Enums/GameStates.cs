using System;

namespace ChaosOffice
{
    [FlagsAttribute]
    public enum GameStates
    {
        Adventure = 1,
        Dialog = 2,
        Fight = 4
    }
}