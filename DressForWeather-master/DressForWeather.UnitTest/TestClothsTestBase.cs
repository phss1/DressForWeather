using System.Collections.Generic;

namespace DressForWeather.UnitTest
{
    class TestClothsTestBase
    {
        public readonly IList<string> allCloths = new List<string>
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

        public static IList<string> ExtractColdCloths(IList<string> cloths)
        {
            IList<string> sortedColdCloths = cloths;
            for (int i = 0; i < sortedColdCloths.Count; i++)
            {
                string[] coldClothSplit = (sortedColdCloths[i].Split(','));
                sortedColdCloths[i] = coldClothSplit[0] + "," + coldClothSplit[3];
            }
            return sortedColdCloths;
        }

        public static IList<string> ExtractHotCloths(IList<string> cloths)
        {
            IList<string> testHotCloths = cloths;
            for (int i = 0; i < testHotCloths.Count; i++)
            {
                string[] hotClothsSplit = (testHotCloths[i].Split(','));
                testHotCloths[i] = hotClothsSplit[0] + "," + hotClothsSplit[2];
            }
            return testHotCloths;
        }


    }
    
    class HotCloths : TestClothsTestBase
    {
        private IList<string> _hotCloths;

        public HotCloths(IList<string> newHotCloths)
        {
            _hotCloths = newHotCloths;
        }

        public IList<string> savedHotCloths
        {
            get => _hotCloths;
            set => _hotCloths = value;
        }
    }

    class ColdCloths : TestClothsTestBase
    {
        private IList<string> _coldCloths;

        public ColdCloths(IList<string> newColdCloths)
        {
            _coldCloths = newColdCloths;
        }

        public IList<string> savedColdCloths
        {
            get => _coldCloths;
            set => _coldCloths = value;
        }
    }
}