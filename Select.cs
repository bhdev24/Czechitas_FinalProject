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

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line);
                }
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
            else
            {
                //vyjimka;
            }

            List<string> data = LoadCsv(filePath);
            Random random = new Random();
            int index = random.Next(data.Count);
            string randomWord = data[index];
            return randomWord;


        }
    }
}
