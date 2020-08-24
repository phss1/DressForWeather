using System;

namespace DressForWeather
{
    public class Utilities
    {
        public enum ClothingArticle
        {
            footWear = 1,
            headWear = 2,
            socks = 3,
            shirt = 4,
            jacket = 5,
            legWear = 6,
            leaveHouse = 7,
            pajamas = 8
        }

        public static bool LeaveHouseAfterClothsOn(string[] userInputSplit, CurrentDress changeCloths)
        {
            int placeHolder = (userInputSplit.Length) - 1;
            if (!userInputSplit[placeHolder].Contains(
                ClothingArticle.leaveHouse.GetHashCode().ToString()))
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool IsShoeWornBeforePants(string userInputCopy, int shoeIndex, CurrentDress changeCloths)
        {
            int leggingIndex = userInputCopy.IndexOf(((int)ClothingArticle.legWear).ToString());
            if (shoeIndex < leggingIndex)
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool DoesInputStartsWithNum8(string[] userInputSplit, CurrentDress changeCloths)
        {
            if (!userInputSplit[0].Contains(((int)ClothingArticle.pajamas).ToString()))
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool CheckInputHasReqNumb(string userInputCopy, CurrentDress changeCloths)
        {
            if (!userInputCopy.Contains(((int)ClothingArticle.legWear).ToString()) ||
                !userInputCopy.Contains(((int)ClothingArticle.shirt).ToString()) ||
                !userInputCopy.Contains(((int)ClothingArticle.headWear).ToString()) ||
                !userInputCopy.Contains(((int)ClothingArticle.footWear).ToString()))
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool DoesInputHaveDupNumbers(int dupEntryValue, CurrentDress changeCloths)
        {
            if (dupEntryValue > 0)
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool IsInputStrTooShort(string[] userInputSplit, CurrentDress changeCloths)
        {
            if (userInputSplit.Length <= 1)
            {
                changeCloths.Dress = "fail";
                return true;
            }
            return false;
        }

        public static bool AreHotClothsWornCorrectOrder(string userInputData, CurrentDress changeCloths)
        {
            if (userInputData.Contains("hot"))
            {
                if (NotAttemptingToWearSocksOrJacket(userInputData, changeCloths) ||
                    IsWearingShirtBeforeGlasses(userInputData, changeCloths))
                    return true;
            }

            return false;
        }

        public static bool NotAttemptingToWearSocksOrJacket(string userInputData, CurrentDress changeCloths)
        {
            if (userInputData.Contains(((int)ClothingArticle.socks).ToString()) ||
                userInputData.Contains(((int)ClothingArticle.jacket).ToString()))
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }

            return false;
        }

        public static bool IsWearingShirtBeforeGlasses(string userInputData, CurrentDress changeCloths)
        {
            int headWearIndex = userInputData.IndexOf(((int)ClothingArticle.headWear).ToString());
            int shirtIndex = userInputData.IndexOf(((int)ClothingArticle.legWear).ToString());
            if (headWearIndex < shirtIndex)
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool AreColdClothsWornCorrectOrder(string userInputData, int shoeIndex, CurrentDress changeCloths)
        {
            if (userInputData.Contains("cold"))
            {
                int socksIndex = userInputData.IndexOf(((int)ClothingArticle.socks).ToString());
                if (NotWearingShoesBeforeSocks(shoeIndex, socksIndex, changeCloths) || 
                    NotWearingSocksOrJacket(userInputData, changeCloths) || 
                    NotWearingJacketBeforeShirt(userInputData, changeCloths))
                    return true;
            }
            return false;
        }

        public static bool NotWearingShoesBeforeSocks(int shoeIndex, int socksIndex, CurrentDress changeCloths)
        {
            if (shoeIndex < socksIndex)
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool NotWearingSocksOrJacket(string userInputData, CurrentDress changeCloths)
        {
            if (!userInputData.Contains(((int)ClothingArticle.socks).ToString()) ||
                !userInputData.Contains(((int)ClothingArticle.jacket).ToString()))
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool NotWearingJacketBeforeShirt(string userInputData, CurrentDress changeCloths)
        {
            int jacketIndex = userInputData.IndexOf(((int)ClothingArticle.jacket).ToString());
            int shirtIndex2 = userInputData.IndexOf(((int)ClothingArticle.shirt).ToString());
            int headWearIndex2 = userInputData.IndexOf(((int)ClothingArticle.headWear).ToString());
            if (jacketIndex < shirtIndex2 &&
                headWearIndex2 < shirtIndex2)
            {
                changeCloths.Dress = changeCloths.Dress + ", fail";
                return true;
            }
            return false;
        }

        public static bool ColdHotClothBreakConditions(string userInputData, string methodResults, CurrentDress changeCloths)
        {
            string dupEntryResult = methodResults.Substring(methodResults.IndexOf(", ") + 2, 1);
            int dupEntryValue = Convert.ToInt32(dupEntryResult);
            if (DoesInputHaveDupNumbers(dupEntryValue, changeCloths) ||
                IsInputStrTooShort(methodResults.Remove(methodResults.IndexOf(", ")).Split(','), changeCloths))
                return true;

            string[] userInputSplit = userInputData.Split(',');

            if (LeaveHouseAfterClothsOn(userInputSplit, changeCloths) ||
                IsShoeWornBeforePants(userInputData, Int32.Parse(userInputData.IndexOf(((int)ClothingArticle.footWear).ToString()).ToString()), changeCloths) ||
                CheckInputHasReqNumb(userInputData, changeCloths) ||
                DoesInputStartsWithNum8(methodResults.Remove(methodResults.IndexOf(", ")).Split(','), changeCloths))
                return true;
            return false;
        }

        public static string FindDuplicateNumbers(string userInput, int placeHolder, int v)
        {
            return (placeHolder > 1) ? userInput.Remove(v, 1) : null;
        }

        public static bool ContainsDupNumber(string dupNumber, string testString)
        {
            return testString.Contains(dupNumber);
        }

        public static string GetFindDupEntryReturnValue(string newUserInput, string userInput, int dupEntry)
        {
            string newInput = "";
            newInput = (newUserInput != null && newUserInput != "") ? newUserInput : userInput;

            var returnValue = String.Format("{0}, {1}", newInput, dupEntry);
            return returnValue;
        }
    }
}