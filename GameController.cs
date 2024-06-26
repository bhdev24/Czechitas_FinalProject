using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject_BH2
{
    internal class GameController
    {

        public static void welcome()
        {
            //welcome page
            Console.WriteLine("Czechitas C# 2: final project");
            Console.WriteLine("Barbora Halova");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Game: Hangman");
            Console.WriteLine("");
        
        }

        public static string difficulty()
        {
            string difficulty;
            bool selected = false;
            do
            {
                Console.WriteLine("Please input the desired difficulty: easy ; medium ; hard");
                difficulty = Console.ReadLine();

                if (difficulty == "easy")
                {
                    Console.Clear();
                    Console.WriteLine("You've selected: difficulty - easy");
                    selected = true;
                }
                else if (difficulty == "medium")
                {
                    Console.Clear();
                    Console.WriteLine("You've selected: difficulty - medium");
                    selected = true;
                }
                else if (difficulty == "hard")
                {
                    Console.Clear();
                    Console.WriteLine("You've selected: difficulty - hard");
                    selected = true;
                }
                else
                {
                    Console.WriteLine("Sorry, that is not a difficulty, please try again.");
                    Console.ReadLine();
                }
            }
            while (selected == false);


            // use the input for selectWord method 
            string Word = Select.selectWord(difficulty);
            Console.WriteLine("Please press Enter to start a game.");
            Console.ReadLine();
            Console.Clear();
            return Word;
        }

        public static void end(int correctCount, string Word, int wrong)
        {
            if (correctCount == Word.Length)
            {
                Console.WriteLine("Congratulations! You've won.");
                Console.ReadLine();
            }
            else if (wrong == 6)
            {
                Console.WriteLine("Oh no! You've lost.");
                Console.WriteLine($"The word was: {Word}");
                Console.ReadLine();
            }
        }

        public static (int, int) body(int wrong, string Word, string currentStatus, int correctCount, string currentGuessed, List<char> lettersGuessed)
        {
            do
            {
                Console.WriteLine("Guess a letter");
                //while loop to ensure single char input is valid and a letter
                bool guessed = false;
                char letterGuessed = ' ';
                do
                {
                    string letterGuessedS = Console.ReadLine();
                    if (string.IsNullOrEmpty(letterGuessedS))
                    {
                        Console.WriteLine("Your guess was empty. Please input exactly one letter.");
                    }
                    else if (letterGuessedS.Length > 1)
                    {
                        Console.WriteLine("You inputted more than one character. Please input exactly one letter.");
                    }
                    else
                    {
                        letterGuessed = letterGuessedS.ToLower()[0];
                        if (char.IsLetter(letterGuessed) == true)
                        {
                            guessed = true;
                        }
                        else
                        {
                            Console.WriteLine("You did not input a letter. Please input exactly one letter.");
                        }
                    }



                }
                while (guessed == false);


                if (lettersGuessed.Contains(letterGuessed))
                {
                    Print.printHangman(wrong);
                    Console.WriteLine("You already tried this letter.");
                    currentStatus = Print.printWord(lettersGuessed, Word);
                    Console.WriteLine(currentStatus);
                    Print.printLines(Word);
                    currentGuessed = Print.printGuessed(lettersGuessed);
                    Console.WriteLine($"Guessed letters: {currentGuessed}");

                }
                else
                {
                    lettersGuessed.Add(letterGuessed);
                    if (Word.Contains(letterGuessed))
                    {
                        Print.printHangman(wrong);
                        Console.WriteLine("That is correct.");
                        currentStatus = Print.printWord(lettersGuessed, Word);
                        Console.WriteLine(currentStatus);
                        Print.printLines(Word);
                        correctCount = Print.countCorrect(lettersGuessed, Word);
                        currentGuessed = Print.printGuessed(lettersGuessed);
                        Console.WriteLine($"Guessed letters: {currentGuessed}");
                    }
                    else
                    {
                        wrong += 1;
                        Print.printHangman(wrong);
                        Console.WriteLine("That is not correct.");
                        currentStatus = Print.printWord(lettersGuessed, Word);
                        correctCount = Print.countCorrect(lettersGuessed, Word);
                        Console.WriteLine(currentStatus);
                        Print.printLines(Word);
                        currentGuessed = Print.printGuessed(lettersGuessed);
                        Console.WriteLine($"Guessed letters: {currentGuessed}");
                    }
                }
            }
            while (correctCount != Word.Length && wrong != 6);

            return (correctCount, wrong);
        }

    }
}
