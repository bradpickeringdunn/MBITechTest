using System.Collections.Generic;

namespace MBI.Client.Models.Calculator
{
    public class CalculatorModel
    {
        public CalculatorModel()
        {
            PrimeNumbers = new List<int>();
        }

        public int PrimeNumber { get; set; }

        public IList<int> PrimeNumbers { get; set; }

        public string ErrorMessage { get; set; }
    }
}
