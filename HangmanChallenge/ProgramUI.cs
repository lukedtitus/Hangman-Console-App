using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanChallenge
{
    class ProgramUI
    {
        public int strike = 0;
        public string difficulty;

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
            Console.Clear();
            Console.WriteLine("Now, choose the difficulty for player 2.\n\t" +
                   "Easy: 10 lives\n\t" +
                   "Medium: 6 lives\n\t" +
                   "Hard: 3 lives");
            difficulty = Console.ReadLine().ToLower();
            int lives = ChooseDifficulty(difficulty);
            Console.Clear();
            Console.WriteLine("Now, give the device to player 2. Let's see if they can read your mind! :)\n\n" +
                "Press enter to start the game...");
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
            List<char> _incorrectChar = new List<char>();

            bool win = false;
            int lettersRevealed = 0;


            while (!win && strike != lives)
            {
                DisplayHangman();
                Console.WriteLine("Incorrect guesses:");
                foreach (char c in _incorrectChar)
                {
                        Console.WriteLine($"{c}, ");
                }
                Console.WriteLine("\n\n");
                Console.WriteLine(displayString.ToString());
                Console.WriteLine("\nGuess a letter");
                char guess = char.Parse(Console.ReadLine());

                Console.Clear();

                if (correctChar.Contains(guess))
                {
                    Console.WriteLine($"You already guessed {guess} and it was correct!");
                    continue;
                }
                else if (_incorrectChar.Contains(guess))
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
                    _incorrectChar.Add(guess);
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
                DisplayHangman();
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public void DisplayHangman()
        {
            if (difficulty == "hard")
            {
                if (strike == 0)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 1)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 2)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|      /|\\\n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 3)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|      /|\\\n" +
                        "|      / \\\n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
            }
            else if (difficulty == "medium")
            {
                if (strike == 0)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 1)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 2)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|       |  \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 3)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|      /|  \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 4)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|      /|\\\n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 5)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|      /|\\\n" +
                        "|      /   \n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
                else if (strike == 6)
                {
                    Console.WriteLine("\n" +
                        "__________ \n" +
                        "|       |  \n" +
                        "|       0  \n" +
                        "|      /|\\\n" +
                        "|      / \\\n" +
                        "|          \n" +
                        "|          \n" +
                        "|          \n\n");
                }
            }
            else if (difficulty == "easy")
            {
                if (strike == 0)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         |  \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 1)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 2)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 3)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 4)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 5)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|       4 2 4\n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 6)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|       4 2 4\n" +
                        "|      4  2  4\n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 7)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|       4 2 4\n" +
                        "|      4  2  4\n" +
                        "|        6 6 \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 8)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|       4 2 4\n" +
                        "|      4  2  4\n" +
                        "|        6 6 \n" +
                        "|       6   6 \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 9)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|       4 2 4\n" +
                        "|      4  2  4\n" +
                        "|        6 6 \n" +
                        "|       6   6 \n" +
                        "|      6     6\n" +
                        "|            \n" +
                        "|            \n" +
                        "|            \n\n");
                }
                else if (strike == 10)
                {
                    Console.WriteLine("\n" +
                        "____________ \n" +
                        "|         +  \n" +
                        "|         1  \n" +
                        "|        1 1 \n" +
                        "|         1  \n" +
                        "|        424 \n" +
                        "|       4 2 4\n" +
                        "|      4  2  4\n" +
                        "|        6 6 \n" +
                        "|       6   6 \n" +
                        "|      6     6\n" +
                        "|     6       6\n" +
                        "|            \n" +
                        "|            \n\n");
                }
            }
        }
    }
}



//if (incorrectChar.Count == 0)
//                {
//Console.WriteLine("\n" +
//"__________ \n" +
//"|       |  \n" +
//"|       0  \n" +
//"|      /|\ \n" +
//"|      / \ \n" +
//"|          \n" +
//"|          \n" +
//"|          \n");
//                }
//                else if (incorrectChar.Count == 1)
//                {
//                    Console.WriteLine("\n" +
//                        "__________ \n" +
//                        "|       |  \n" +
//                        "|       0  \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n");
//                }
//                else if (incorrectChar.Count == 2)
//                {
//                    Console.WriteLine("\n" +
//                        "__________ \n" +
//                        "|       |  \n" +
//                        "|       0  \n" +
//                        "|       |  \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n");
//                }
//                else if (incorrectChar.Count == 3)
//                {
//                    Console.WriteLine("\n" +
//                        "__________ \n" +
//                        "|       |  \n" +
//                        "|       0  \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n" +
//                        "|          \n");
//                }