using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DressForWeather;

namespace DressForWeather.UnitTest
{
    [TestClass]
    public class HotClothsFailure
    {
        private const string testDupEntry = "HOT 8,6,6";
        private const string dupEntryResult = "Removing PJs, shorts, fail";

        private const string testWrongInput = "HOT 8,6,3";
        private const string wrongInputResult = "Removing PJs, shorts, fail, fail";
        
        private static readonly IList<string> cloths = new List<string>
        {
            "1,Put on footwear,sandals,boots",
            "2,Put on headwear,sun visor,hat",
            "3,Put no socks,fail,socks",
            "4,put on shirt,t-shirt,shirt",
            "5,put on jacket,fail,jacket",
            "6,Put on pants,shorts,pants",
            "7,Leave house,leaving house,leaving house",
            "8,Take off pajamas,Removing PJs,Removing PJs"
        };
        private static readonly IList<string> hotCloths = new List<string>(ExtractHotCloths(cloths));

        [TestMethod]
        public void TestUserInputForAnyHotNumbersEnteredMoreThanOnce()
        {
            CurrentDress returnedResult = CurrentDress.SortCloths(testDupEntry, hotCloths);
            string actualResult = returnedResult.Dress;
            Assert.AreEqual(dupEntryResult, actualResult);
        }

        [TestMethod]
        public void EnsureFailureWhenUserInputContainsIncorrectHotClothsNumbericOrder()
        {
            CurrentDress returnedResult = CurrentDress.SortCloths(testWrongInput, hotCloths);
            string actualResult = returnedResult.Dress;
            Assert.AreEqual(wrongInputResult, actualResult);
        }

        private static IList<string> ExtractHotCloths(IList<string> hotCloths)
        {
            IList<string> sortedHotCloths = hotCloths;
            for (int i = 0; i < sortedHotCloths.Count; i++)
            {
                string[] hotClothSplit = (sortedHotCloths[i].Split(','));
                sortedHotCloths[i] = hotClothSplit[0] + "," + hotClothSplit[2];
            }
            return sortedHotCloths;
        }
    }
}
