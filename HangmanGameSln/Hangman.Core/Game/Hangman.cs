using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _guessProgress;
        private int _numberOfLives;
        private string letter;
        //
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {

            _numberOfLives = 6;


            _renderer.Render(5, 5, 6);

            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            

            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 17);

            Console.ForegroundColor = ConsoleColor.Green;

          //  Console.Write("_");
           // var nextGuess = Console.ReadLine();

            Random random = new Random();

            string[] Listwords = new string[] { "Company", "words", "hate", "computer", "house", "university", "address", "playstation", "laptop", "bread", "food", "typing", "reading", "water", "cat", "phone", "paper", "toilet", "table", "pen" };

            var index = random.Next(0, 9);

            string GuessedWords = Listwords[index];


            char[] guess = GuessedWords.ToCharArray();

            for (int i = 0; i < guess.Length; i++)
            {
                _guessProgress += "*";
                Console.SetCursorPosition(0, 17);
            }

            while (_numberOfLives > 0)
            {

                _renderer.Render(5, 5, _numberOfLives);

                Console.SetCursorPosition(0, 17);

                char playerguess = char.Parse(Console.ReadLine());
                

                char[] guessProgressArray = _guessProgress.ToCharArray();
                //Console.SetCursorPosition(0, 17);

                bool correct = false;

                for (int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] == playerguess)
                    {
                        guessProgressArray[i] = guess[i];
                        correct = true;
                    }
                }
                _guessProgress = new string(guessProgressArray);
                Console.SetCursorPosition(0, 18);


                Console.WriteLine(_guessProgress);

                if (!correct)
                {
                    _numberOfLives--;
                    _renderer.Render(5, 5, _numberOfLives);


                }

            }


            Console.SetCursorPosition(2, 22);

            if (_numberOfLives == 0)
            {
                Console.WriteLine($"you died.");
            }
            else
            {
                Console.WriteLine($"you won with {_numberOfLives} left.");
            }

        }



    }
}
