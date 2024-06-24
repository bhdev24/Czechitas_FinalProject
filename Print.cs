using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BH2
{
    internal class Print
    {

        public static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {

                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.Clear();
                Console.WriteLine($"Statistics: {wrong}/6 lifes");
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        public static void printLines(string Word)
        {
            Console.Write("\r");
            foreach (char x in Word)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");

            }
        }

        public static string printWord(List<char> lettersGuessed, string Word)
        {
            string status = "";
            Console.Write("\r\n");
            foreach (char x in Word)
            {
                if (lettersGuessed.Contains(x))
                {
                    status = status + (x + " ");
                }
                else
                {
                    status = status + ("  ");
                }
            }
            return status;
        }

        public static int countCorrect(List<char> lettersGuessed, string Word)
        {
            int counter = 0;
            foreach (char x in Word)
            {
                if (lettersGuessed.Contains(x))
                {
                    counter +=1;
                }
                else
                {
                    
                }
            }
            return counter;
        }

        public static string printGuessed(List<char> lettersGuessed)
        {
            string status = "";
            Console.Write("\r\n");
            foreach (char x in lettersGuessed)
            {
                status = status + x + " ";
            }
            return status;
        }
    }

}
