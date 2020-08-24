using System;
using System.Collections.Generic;
using System.Linq;

namespace DressForWeather
{
    public class CurrentDress
    {
        private string _currentDress;

        public CurrentDress(string newDressStatus)
        {
            _currentDress = newDressStatus;
        }

        public string Dress
        {
            get => _currentDress;
            set => _currentDress = value;
        }

        public static CurrentDress SortCloths(string userInputData, IList<string> cloths)
        {
            int iterationCount = 1;
            string[] userInputSplit = userInputData.Split(',');
            CurrentDress changeCloths = new CurrentDress("");
            for (int y = 0; y < iterationCount; y++)
            {
                string methodResults = changeCloths.FindDupEntries(userInputData, userInputSplit);
                changeCloths = changeCloths.TranslateInput(new ClothsList(methodResults.Remove(methodResults.IndexOf(", ")).Split(','), cloths), changeCloths);

                if (Utilities.ColdHotClothBreakConditions(userInputData, methodResults, changeCloths))
                    return changeCloths;

                int shoeIndex = userInputData.IndexOf(((int)Utilities.ClothingArticle.footWear).ToString());
                if (Utilities.AreHotClothsWornCorrectOrder(userInputData, changeCloths) ||
                    Utilities.AreColdClothsWornCorrectOrder(userInputData, shoeIndex,
                        changeCloths))
                {
                    return changeCloths;
                }
            }
            return changeCloths;
        }
        
        private string FindDupEntries(string userData, string[] inputSplit)
        {
            string[] numbersList = ("1,2,3,4,5,6,7,8").Split(',');
            string[] userInputArray = new string[1];
            string userInput = userData;
            userInputArray[0] = userData;

            string newUserInput = "";
            int expectedDupEntry = 0;
            int numberOccurances = 1;
            string[] userInputSplit = inputSplit;
            for (int x = 0; x < numbersList.Length; x++)
            {
                int count = userInputSplit.Count(f => f == numbersList[x]);
                if (count > numberOccurances)
                {
                    expectedDupEntry = 1;
                    string dupNumber = numbersList[x];
                    newUserInput = CorrectedUserInput(userInput, dupNumber);
                }
            }
            var returnValue = Utilities.GetFindDupEntryReturnValue(newUserInput, userInput, expectedDupEntry);
            return returnValue;
        }


        private static string CorrectedUserInput(string userInput, string dupNumber)
        {
            string newUserInput = userInput;
            int placeHolder = 0;
            for (int v = 0; v < userInput.Length; v++)
            {
                string userInputString = userInput.Substring(v, 1);
                if (Utilities.ContainsDupNumber(dupNumber, userInputString))
                {
                    placeHolder++;
                    newUserInput = Utilities.FindDuplicateNumbers(userInput, placeHolder, v);
                }
            }
            return newUserInput;
        }

        private CurrentDress TranslateInput(ClothsList clothsList, CurrentDress dress)
        {
            CurrentDress translateInputDress = dress;
            translateInputDress = dress;
            for (int z = 0; z < clothsList.UserInput.Length; z++)
            {
                translateInputDress = SetNewDress(clothsList, z, translateInputDress);
            }
            return translateInputDress;
        }

        private static CurrentDress SetNewDress(ClothsList clothsList, int z, CurrentDress translateInputDress)
        {
            for (int i = 0; i < clothsList.Cloths.Count; i++)
            {
                string hotClothNum = clothsList.Cloths[i].Split(',')[0];
                string hotClothArticle = clothsList.Cloths[i].Split(',')[1];
                if (clothsList.UserInput[z].Contains(hotClothNum))
                {
                    translateInputDress.Dress = String.IsNullOrEmpty(translateInputDress.Dress)
                        ? hotClothArticle
                        : translateInputDress.Dress + ", " + hotClothArticle;
                }
            }
            return translateInputDress;
        }
    }
}