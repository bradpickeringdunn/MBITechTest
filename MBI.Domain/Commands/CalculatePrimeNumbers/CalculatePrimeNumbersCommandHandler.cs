using System.Collections.Generic;

namespace MBI.Domain.Commands.CalculatePrimeNumbers
{
    public class CalculatePrimeNumbersCommandHandler : ICalculatePrimeNumbersCommandHandler
    {
        public CalculatePrimeNumbersResult Execute(CalculatePrimeNumbersCommand command)
        {
            var result = new CalculatePrimeNumbersResult();

            if (!IsValidPrimeNumber(command.PrimeNumber))
            {
                result.ErrorMessage = $"{command.PrimeNumber} is not a valid prime number";
                return result;
            }

            CalculatePrimeNumbers(command.PrimeNumber, result.PrimeNumbers);
           
            return result;
        }

        private void CalculatePrimeNumbers(int targetPrimeNumber, IList<int> calculatedPrimeNumbers = null, int currentPrimePosition = 0)
        {
            calculatedPrimeNumbers = calculatedPrimeNumbers ?? new List<int>();

            if (currentPrimePosition < targetPrimeNumber)
            {
                do
                {
                    currentPrimePosition++;
                }
                while (!IsValidPrimeNumber(currentPrimePosition));
                calculatedPrimeNumbers.Add(currentPrimePosition);
                CalculatePrimeNumbers(targetPrimeNumber, calculatedPrimeNumbers, currentPrimePosition);
            }
        }

        public bool IsValidPrimeNumber(int primeNumber)
        {
            for (int i = 2; i < primeNumber; i++)
                if (primeNumber % i == 0)
                    return false;
            return true;
        }
    }
}
