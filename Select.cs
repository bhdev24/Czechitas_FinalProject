using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_BH2
{
    internal class Select
    {
        static List<string> LoadCsv(string filePath)
        {
            List<string> data = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file at path '{filePath}' was not found.");
                Console.ReadLine();
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Error: The directory for path '{filePath}' was not found.");
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ReadLine();
            }
            return data;
        }

        public static string selectWord(string difficulty)
        {
            string projectDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            string filePath = "";
            if (difficulty == "easy")
            {
                filePath = projectDirectory + @"\easy.csv";
            }
            else if (difficulty == "medium")
            {
                filePath = projectDirectory + @"\medium.csv";
            }
            else if (difficulty == "hard")
            {
                filePath = projectDirectory + @"\hard.csv";
            }

            List<string> data = LoadCsv(filePath);
            
            if (data.Count == 0)
            {
                throw new InvalidOperationException("The csv file has invalid data or is empty.");
            }

            Random random = new Random();
            int index = random.Next(data.Count);
            string randomWord = data[index];
            return randomWord;


        }
    }
}
