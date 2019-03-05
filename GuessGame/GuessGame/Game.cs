using System;
using System.Collections.Generic;

namespace GuessGame
{
    public class Game
    {
        private readonly int _rangeFirst;
        private readonly int _rangeSecond;

        private readonly string[] _cheeringPhrases =
        {
            "Let's try one more time, sun!",
            "You can do it, sweetie!",
            "Believe in yourself, dear!",
            "Come on now!",
            "Think again..."
        };
        
        private Dictionary<int, string> _attemptHistory = new Dictionary<int, string>();

        public Game(int first, int second)
        {
            _rangeFirst = first;
            _rangeSecond = second;
        }

        public void Start()
        {
            var guessNumber = new Random().Next(_rangeFirst, _rangeSecond);
            Console.WriteLine("Please, enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine("\nHello, {0}! Let's play the Guessing Game! Rules are very simple - try to think, " +
                              "what number we're thinking of (from {1} to {2}). If you get tired - just enter \'q\'." +
                              "\n", name, _rangeFirst, _rangeSecond);

            var startTime = DateTime.Now;
            int userNumber;
            var attemptCount = 0;
            while ((userNumber = int.Parse(Console.ReadLine())) != guessNumber)
            {
                attemptCount++;
                if (userNumber > guessNumber)
                {
                    _attemptHistory.Add(userNumber, "smaller");
                    Console.WriteLine("Guessing number is smaller than {0}.", userNumber);
                }
                else
                {
                    _attemptHistory.Add(userNumber, "bigger");
                    Console.WriteLine("Guessing number is bigger than {0}.", userNumber);
                }

                if (attemptCount % 4 == 0)
                {
                    var phraseNumber = new Random().Next(_cheeringPhrases.Length);
                    Console.WriteLine(_cheeringPhrases[phraseNumber]);
                }
            }

            while (true)
            {
                var userStringNumber = Console.ReadLine();
                if (userStringNumber == "q")
                {
                    Console.WriteLine("Bye! Come again.");
                    return;
                }
                userNumber = int.Parse(userStringNumber);
                try
                {

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                if (userNumber == guessNumber)
                {
                    break;
                }
                if (userNumber > guessNumber)
                {
                    _attemptHistory.Add(userNumber, "smaller");
                    Console.WriteLine("Guessing number is smaller than {0}.", userNumber);
                }
                else
                {
                    _attemptHistory.Add(userNumber, "bigger");
                    Console.WriteLine("Guessing number is bigger than {0}.", userNumber);
                }
                if (attemptCount % 4 == 0)
                {
                    var phraseNumber = new Random().Next(_cheeringPhrases.Length);
                    Console.WriteLine(_cheeringPhrases[phraseNumber]);
                }
            }
            var endTime = DateTime.Now;
            var interval = endTime - startTime;
            Console.WriteLine("\nYeah, you're absolutely right! Congratulations, you win! \nYou're statistics:");
            Console.WriteLine("Guessing time = {0} min {1} sec", interval.Minutes, interval.Seconds);
            Console.WriteLine("Guessing attempts = {0}", attemptCount);
            Console.WriteLine("Attempt history:");
            foreach (var (key, value) in _attemptHistory)
            {
                Console.WriteLine("{0}: {1} then {2}", key, value, guessNumber);
            }
        }
    }
}