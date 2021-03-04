using System.Collections.Generic;

namespace MBI.Domain.Commands.CalculatePrimeNumbers
{
    public class CalculatePrimeNumbersResult
    {
        public CalculatePrimeNumbersResult()
        {
            PrimeNumbers = new List<int>();
        }

        public string ErrorMessage { get; internal set; }

        public int PrimeNumber { get; set; }

        public IList<int> PrimeNumbers { get; set; }
    }
}
