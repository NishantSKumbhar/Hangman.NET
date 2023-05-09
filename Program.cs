using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Random_Names;


namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string hiddenWord1 = Names.getRandomName();
            string hiddenWord = hiddenWord1.ToUpper();
            

            int LIVES = 5;
            char[] ans = new char[hiddenWord1.Length];
            for(int i = 0; i < ans.Length; i++)
            {
                ans[i] = '-';
            }

            char[] ansArr = new char[hiddenWord.Length];
            for(int i = 0; i < ansArr.Length; i++)
            {
                ansArr[i] = hiddenWord[i];
            }

            List<char> usedLetters = new List<char>();

            do
            {
                
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("\t ||   Hangman Game   ||\t");
                Console.WriteLine("----------------------------------------");
                //Console.WriteLine($"Hidden Word  : {hiddenWord}");
                Console.WriteLine($"*** Lives left : {LIVES} ****");
                Console.Write("\nCurrent Word State : ");
                for (int i = 0; i < ans.Length; i++)
                {
                    Console.Write(ans[i] + " ");
                }
                //Console.Write("\nAnswer Word  : ");
                //for (int i = 0; i < ansArr.Length; i++)
                //{
                //    Console.Write(ansArr[i] + " ");
                //}
               
                Console.WriteLine("\nUsed Characters : ");
                printUsedLetters(usedLetters);
                Console.WriteLine("\nEnter the Character : ");
                char c = Console.ReadLine()[0];
                char input = char.ToUpper(c);
                Console.WriteLine($"\nYour Letter : {input}.");
                // check if letter in ans array
                bool wordExist = checkIfLetterInWord(input, ansArr);

                if (wordExist)
                {

                    // - to char
                    if(!isPresentInUsedLetters(input, usedLetters))
                    {
                        List<int> lseq = getTheSequenceOfChar(input, ansArr);

                        for (int i = 0; i < lseq.Count; i++)
                        {
                            ans[lseq[i]] = input;
                        }
                        usedLetters.Add(input);
                    }
                    else
                    {
                        Console.WriteLine("You have alreday used this letter.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Wrong Answer , Please try again !");
                    if(isPresentInUsedLetters(input, usedLetters))
                    {
                        Console.WriteLine("Already, used letter. Please try different letter.");
                    }
                    else
                    {
                        usedLetters.Add(input);
                        LIVES--;
                    }
                    
                }
                

                

                Console.ReadKey();
                Console.Clear();
            } while(LIVES > 0 && !win(ans));

            if (win(ans))
            {
                Console.WriteLine("Congratulations , You Win the Game.");
            }
            else
            {
                Console.WriteLine("You Lost the Game : ( ");
                Console.WriteLine(" +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
            }
        }

        static bool win(char[] ans)
        {
            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i] == '-')
                {
                    return false;
                }
            }

            
            return true;
        }


        static List<int> getTheSequenceOfChar(char c, char[] ansArr)
        {
            List<int> seq = new List<int>();
            for(int i = 0; i < ansArr.Length; i++)
            {
                if (ansArr[i] == c)
                {
                    seq.Add(i);
                }
            }
            return seq;
        }

        static bool isPresentInUsedLetters(char c, List<char> arr)
        {
            
            for(int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == c)
                {
                    return true;
                }
            }
            return false;
        }


        static void printUsedLetters(List<char> l)
        {
            for(int i = 0; i < l.Count;i++)
            {
                Console.Write(l[i] + " ,");
            }
        }

        static bool checkIfLetterInWord(char c, char[] ansArr )
        {
            for(int i = 0; i < ansArr.Length; i++)
            {
                if (ansArr[i] == c)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
