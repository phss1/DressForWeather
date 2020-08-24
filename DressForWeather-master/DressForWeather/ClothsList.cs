using System.Collections.Generic;

namespace DressForWeather
{
    public class ClothsList
    {
        public ClothsList(string[] userInput, IList<string> cloths)
        {
            UserInput = userInput;
            Cloths = cloths;
        }

        public string[] UserInput { get; set; }
        public IList<string> Cloths { get; set; }
    }
}