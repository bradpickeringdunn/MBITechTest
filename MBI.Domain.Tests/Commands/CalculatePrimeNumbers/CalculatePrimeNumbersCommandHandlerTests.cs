using FluentAssertions;
using MBI.Domain.Commands.CalculatePrimeNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MBI.Domain.Tests.Commands.CalculatePrimeNumbers
{
    [TestClass]
    public class CalculatePrimeNumbersCommandHandlerTests
    {
        [TestMethod]
        public void Ensure_Non_Prime_Numbers_Return_Message()
        {
            var handler = new CalculatePrimeNumbersCommandHandler();
            var result = handler.Execute(new CalculatePrimeNumbersCommand()
            {
                PrimeNumber = 4
            });

            result.ErrorMessage.Should().Be($"4 is not a valid prime number");
        }

        [TestMethod]
        public void Ensure_Prime_Numbers_Are_Returned()
        {
            var handler = new CalculatePrimeNumbersCommandHandler();
            var result = handler.Execute(new CalculatePrimeNumbersCommand()
            {
                PrimeNumber = 5
            });

            result.PrimeNumbers.Count.Should().Be(4);
        }
    }
}
