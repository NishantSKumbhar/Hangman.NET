using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Random_Names
{
    internal class Names
    {
        static string[] names()
        {
            string[] names = new string[10];
            names[0] = "Cricket";
            names[1] = "Tree";
            names[2] = "Green";
            names[3] = "Earth";
            names[4] = "Mathematics";
            names[5] = "Science";
            names[6] = "India";
            names[7] = "Umbrella";
            names[8] = "Computer";
            names[9] = "God";
            return names;
        }

        public static string getRandomName()
        {
            Random rnd = new Random();
            string[] randomNames = names();
            int i = rnd.Next(randomNames.Length);
            //Console.WriteLine($"random i : {i} and word : {randomNames[i]}");
            return randomNames[i];
        }
    }
}
