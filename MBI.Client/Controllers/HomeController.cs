using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MBI.Client.Models;
using MBI.Domain.Commands.CalculatePrimeNumbers;
using MBI.Client.Models.Calculator;

namespace MBI.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculatePrimeNumbersCommandHandler _calculatePrimeNumbersCommandHandler;

        public HomeController(ILogger<HomeController> logger, ICalculatePrimeNumbersCommandHandler calculatePrimeNumbersCommandHandler)
        {
            _logger = logger;
            _calculatePrimeNumbersCommandHandler = calculatePrimeNumbersCommandHandler;
        }

        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult CalculatePrimes(CalculatorModel model)
        {
            if (model.PrimeNumber <= 0 || !_calculatePrimeNumbersCommandHandler.IsValidPrimeNumber(model.PrimeNumber))
            {
                model.ErrorMessage = $"{model.PrimeNumber} is not a valid prime number";
            }
            else
            {
                var command = new CalculatePrimeNumbersCommand()
                {
                    PrimeNumber = model.PrimeNumber
                };

                var result = _calculatePrimeNumbersCommandHandler.Execute(command);

                model.PrimeNumbers = result.PrimeNumbers;
                model.ErrorMessage = result.ErrorMessage;
            }

            return View("index", model);
        }

    }
}
