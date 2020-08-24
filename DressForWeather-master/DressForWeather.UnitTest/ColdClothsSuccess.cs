using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DressForWeather;

namespace DressForWeather.UnitTest
{
    [TestClass]
    public class ColdClothsSuccess
    {
        private const string correctSequence = "COLD 8,6,3,4,2,5,1,7";
        private const string expectedTestResult = "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house";

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
    
        [TestMethod]
        public void EnsureUserEnteredColdClothsNumbersInCorrectOrderForSuccess()
        {
            CurrentDress returnedResult = CurrentDress.SortCloths(correctSequence, coldCloths);
            string actualResult = returnedResult.Dress;
            Assert.AreEqual(expectedTestResult, actualResult);
        }

        private static IList<string> ExtractColdCloths(IList<string> coldCloths)
        {
            IList<string> theseColdCloths = coldCloths;
            for (int i = 0; i < theseColdCloths.Count; i++)
            {
                string[] coldClothSplit = (theseColdCloths[i].Split(','));
                theseColdCloths[i] = coldClothSplit[0] + "," + coldClothSplit[3];
            }
            return theseColdCloths;
        }
    }
}