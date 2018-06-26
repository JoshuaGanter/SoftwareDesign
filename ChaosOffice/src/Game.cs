using System;
using System.Collections.Generic;

namespace ChaosOffice
{
    class Game
    {
        private static Game _instance;
        
        public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }
                return _instance;
            }
        }

        public bool IsRunning {get; private set;}
        public Player Player {get; private set;}
        public GameState GameState {get; private set;}
        static void Main(string[] args)
        {
            Game.Instance.Play();
        }

        private Game()
        {
            // init
        }

        private void PrintIntroduction()
        {
            // print intro
        }

        public void Play()
        {
            // kick-off the main loop
        }
    }
}
