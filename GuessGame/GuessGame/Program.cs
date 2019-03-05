using System;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var guessGame = new Game(0, 50);
            guessGame.Start();
        }
    }
}