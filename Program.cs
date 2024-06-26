using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject_BH2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //print out the welcome page
            GameController.welcome();

            // ask for the difficulty, check if input valid
            string Word = GameController.difficulty();

            int wrong = 0;
            List<char> lettersGuessed = new List<char>();
            string currentStatus = "";
            int correctCount = 0;
            string currentGuessed = "";

            //print the basic start
            Print.printStart(wrong, Word);

            //body of the game
            var result = GameController.body(wrong, Word, currentStatus, correctCount, currentGuessed, lettersGuessed);
            correctCount = result.Item1;
            wrong = result.Item2;
        
            // print ending based on the result of the body
            GameController.end(correctCount, Word, wrong);
        }
    }
}
