using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolishVATLib;
using System.Reflection;

namespace PolishVATWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Vat23Controller : ControllerBase
    {
        private readonly IVATCalculation _vatCalculation;

        public Vat23Controller()
        {
            _vatCalculation = new VAT23Calculation();
        }

        [HttpGet]
        [Route("/vat23")]
        ///Calculate gross price
        public string Get(double price, int quantity)
        {
            var grossPrice = _vatCalculation.CalculateGrossAmount(price) * quantity;
            return $"Gross price: {grossPrice.ToString ("0.##")} for quantity: {quantity}";
        }

        [HttpGet]
        [Route("/vat23/net")]
        ///Calculate net price
        public string Net(double price, int quantity)
        {
            var netPrice = _vatCalculation.CalculateNetAmount(price) * quantity;
            return $"Net price: {netPrice.ToString ("0.##")} for quantity: {quantity}";
        }

        [HttpGet]
        [Route("/vat23/tax")]
        ///Calculate tax
        public string Tax(double price, int quantity)
        {
            var tax = _vatCalculation.CalculateTax(price) * quantity;
            return $"Tax: {tax.ToString ("0.##")} for quantity: {quantity}";
        }
    }
}