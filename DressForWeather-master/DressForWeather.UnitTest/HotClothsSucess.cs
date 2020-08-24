using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DressForWeather;

namespace DressForWeather.UnitTest
{
    [TestClass]
    public class HotClothsSuccess
    {
        string testCorrectInput = "HOT 8,6,4,2,1,7";


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
        public void EnsureUserEnteredHotNumbersInCorrectOrderForSuccess()
        {
            IList<string> hotCloths = new List<string>(cloths);

            string expectedResult = "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house";
            CurrentDress returnedResult =  CurrentDress.SortCloths(testCorrectInput, hotCloths);
            string actualResult = returnedResult.Dress;
            Assert.AreEqual(expectedResult, actualResult);
        }

        private static IList<string> ExtractHotCloths(IList<string> hotCloths)
        {
            IList<string> testHotCloths = hotCloths;
            for (int i = 0; i < testHotCloths.Count; i++)
            {
                string[] hotClothsSplit = (testHotCloths[i].Split(','));
                testHotCloths[i] = hotClothsSplit[0] + "," + hotClothsSplit[2];
            }
            return testHotCloths;
        }
    }
}
