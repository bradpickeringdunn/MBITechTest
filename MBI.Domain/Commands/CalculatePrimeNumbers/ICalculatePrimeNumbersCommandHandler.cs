namespace MBI.Domain.Commands.CalculatePrimeNumbers
{
    public interface ICalculatePrimeNumbersCommandHandler
    {
        public CalculatePrimeNumbersResult Execute(CalculatePrimeNumbersCommand command);

        public bool IsValidPrimeNumber(int primeNumber);
    }
}
