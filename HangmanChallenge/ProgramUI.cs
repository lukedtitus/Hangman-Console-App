using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanChallenge
{
    class ProgramUI
    {
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            Console.WriteLine("Welcome to Hangman. Player 1 will enter a word and hand the device to player 2 to guess the word.\n\n" +
                "Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
            string buzzWord = ChooseBuzzword();
            Console.WriteLine("Now, choose the difficulty for player 2.\n\t" +
                   "Easy: 10 lives\n\t" +
                   "Medium: 6 lives\n\t" +
                   "Hard: 3 lives");
            string difficulty = Console.ReadLine().ToLower();
            int lives = ChooseDifficulty(difficulty);
            Console.Clear();
            Console.WriteLine("Now, give the device to player 2. Let's see if they can read your mind! :)\n\n" +
                "Press enter to continue...");
            Console.ReadLine();
            RunGame(buzzWord, lives);
        }

        public string ChooseBuzzword()
        {
            Console.WriteLine("Player 1, enter your buzzword.");
            string buzzword = Console.ReadLine().ToLower();
            return buzzword;
        }

        public int ChooseDifficulty(string difficulty)
        {
            int lives = 0;

            if (difficulty == "easy")
                lives = 10;
            else if (difficulty == "medium")
                lives = 6;
            else if (difficulty == "hard")
                lives = 3;
            else if (difficulty != "easy" && difficulty != "medium" && difficulty != "hard")
            {
                Console.WriteLine("That input was invalid, the difficulty will be medium.");
                lives = 6;
            }

            return lives;
        }

        public void RunGame(string buzzWord, int lives)
        {
            StringBuilder displayString = new StringBuilder(buzzWord.Length);
            for (int i = 0; i < buzzWord.Length; i++)
                displayString.Append('-');
            List<char> correctChar = new List<char>();
            List<char> incorrectChar = new List<char>();
            bool win = false;
            int lettersRevealed = 0;
            int strike = 0;

            while (!win && strike != lives)
            {
                Console.WriteLine(displayString.ToString());
                Console.WriteLine("\nGuess a letter");
                char guess = char.Parse(Console.ReadLine());

                if (correctChar.Contains(guess))
                {
                    Console.WriteLine($"You already guessed {guess} and it was correct!");
                    continue;
                }
                else if (incorrectChar.Contains(guess))
                {
                    Console.WriteLine($"You already guessed {guess} and it was incorrect :(");
                    continue;
                }

                if (buzzWord.Contains(guess))
                {
                    Console.WriteLine("You got one!");
                    correctChar.Add(guess);

                    for (int i = 0; i < buzzWord.Length; i++)
                    {
                        if (buzzWord[i] == guess)
                        {
                            displayString[i] = buzzWord[i];
                            lettersRevealed++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, {guess} is not in the buzzword");
                    incorrectChar.Add(guess);
                    strike++;
                }

                if (lettersRevealed == buzzWord.Length)
                    win = true;
            }

            if (win)
            {
                Console.WriteLine($"Congratulations, the buzzword was {buzzWord}!");
            }
            else
            {
                Console.WriteLine("You lost. Try again.");
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
