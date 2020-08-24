using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DressForWeather
{
    public class Program
    {
        private const int hotClothsColumn = 2;
        private const int coldClothsColumn = 3;

        public static void Main(string argument)
        {
            Console.WriteLine("NOTE: Enter numbers and commas without spaces. EG: hot 8,6,4,2,1,7");
            Console.WriteLine("");

            string userInput = (argument == null) ? Console.ReadLine().ToLower() : argument;
            Match match = CompareInputWithRegex(userInput);
            RunProgramInWhileLoop(userInput, match, argument);
        }

        private static Match CompareInputWithRegex(string userInput)
        {
            Regex regex = new Regex("^(?:hot|cold) 8(?:,[1-7])*$");
            Match match = regex.Match(userInput);
            return match;
        }

        private static void RunProgramInWhileLoop(string userInput, Match match, string consoleProjArg)
        {
            while (!userInput.Contains("exit"))
            {
                IList<string> hotCloths = new List<string>(GetClothsList(hotClothsColumn));
                IList<string> coldCloths = new List<string>(GetClothsList(coldClothsColumn));
                string printToConsoleOutput = match.Success
                    ? GetClothsForCorrect(userInput, hotCloths, coldCloths).Dress
                    : "Invalid Entry Format: Please enter a value with the correct format. EG: hot 8,6,4,2,1,7";

                Console.WriteLine(printToConsoleOutput);
                Console.WriteLine("");
                Console.WriteLine("");

                userInput = (consoleProjArg == null) ? Console.ReadLine().ToLower() : "exit";
            }
        }

        private static CurrentDress GetClothsForCorrect(string userInput, IList<string> hotCloths, IList<string> coldCloths)
        {
            return userInput.Contains("hot")
                ? CurrentDress.SortCloths(userInput, hotCloths)
                : CurrentDress.SortCloths(userInput, coldCloths);
        }

        private static IList<string> GetClothsList(int clothingType)
        {
            IList<string> clothsList = new List<string>
            {
                "1,Put on footwear,sandals,boots",
                "2,Put on headwear,sun visor,hat",
                "3,Put on socks,fail,socks",
                "4,put on shirt,t-shirt,shirt",
                "5,put on jacket,fail,jacket",
                "6,Put on pants,shorts,pants",
                "7,Leave house,leaving house,leaving house",
                "8,Take off pajamas,Removing PJs,Removing PJs"
            };

            for (int i = 0; i < clothsList.Count; i++)
            {
                string[] clothsSplit;

                clothsSplit = (clothsList[i].Split(','));
                clothsList[i] = clothsSplit[0] + "," + clothsSplit[clothingType];
            }
            return clothsList;
        }
    }
}