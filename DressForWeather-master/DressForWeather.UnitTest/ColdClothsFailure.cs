using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DressForWeather.UnitTest
{
    [TestClass]
    public class ColdClothsFailure
    {
        private const string incorrectSequence = "COLD 8,6,3,4,2,5,7";
        private const string wrongInput = "Removing PJs, pants, socks, shirt, hat, jacket, leaving house, fail";

        private const string oneNumberInput = "COLD 6";
        private const string wrongInputResult = "fail";

        private static readonly IList<string> cloths = new List<string>
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

        private static readonly IList<string> coldCloths = new List<string>(ExtractColdCloths(cloths));

        //private static readonly IList<string> coldCloths = new List<string>(ExtractColdCloths(cloths));
        //private TestClothsTestBase test = new TestClothsTestBase();


        [TestMethod]
        public void EnsureFailureWhenUserInputContainsIncorrectColdClothsNumbericOrder()
        {
            CurrentDress returnedResult = CurrentDress.SortCloths(incorrectSequence, coldCloths);
            string actualResult = returnedResult.Dress;
            Assert.AreEqual(wrongInput, actualResult);
    }

        [TestMethod]
        public void ForceFailueWhenUserInputContainsColdClothsWithIncorrectNumberOrder()
        {
            CurrentDress returnedResult = CurrentDress.SortCloths(oneNumberInput, coldCloths);
            string actualResult = returnedResult.Dress;
            Assert.AreEqual(wrongInputResult, actualResult);
        }

        private static IList<string> ExtractColdCloths(IList<string> coldCloths)
        {
            IList<string> sortedColdCloths = coldCloths;
            for (int i = 0; i < sortedColdCloths.Count; i++)
            {
                string[] coldClothSplit = (sortedColdCloths[i].Split(','));
                sortedColdCloths[i] = coldClothSplit[0] + "," + coldClothSplit[3];
            }
            return sortedColdCloths;
        }
    }
}