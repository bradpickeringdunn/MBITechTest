using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBI.Client.Models.Calculator;
using MBI.Domain.Commands.CalculatePrimeNumbers;
using Microsoft.AspNetCore.Mvc;

namespace MBI.Client.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatePrimeNumbersCommandHandler _calculatePrimeNumbersCommandHandler;

        public CalculatorController(ICalculatePrimeNumbersCommandHandler calculatePrimeNumbersCommandHandler)
        {
            _calculatePrimeNumbersCommandHandler = calculatePrimeNumbersCommandHandler;
        }

        [HttpPatch]
        public IActionResult CalculatePrimes(CalculatorModel model)
        {
            return View();
        }
    }
}
