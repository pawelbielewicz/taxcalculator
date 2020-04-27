using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolishVATLib;
using System.Reflection;
using PolishVATWebServices.Repositories;

namespace PolishVATWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Vat8Controller : ControllerBase
    {
        private readonly VATRepository _vatRepository;

        public Vat8Controller()
        {
            _vatRepository = new VATRepository(new VAT8Calculation());
        }

        [HttpGet]
        [Route("/vat8")]
        ///Calculate gross price
        public string Get(double price, int quantity)
        {
            return $"Gross price: {_vatRepository.Gross(price, quantity).ToString ("0.##")} for quantity: {quantity}";
        }

        [HttpGet]
        [Route("/vat8/net")]
        ///Calculate net price
        public string Net(double price, int quantity)
        {
            return $"Net price: {_vatRepository.Net(price, quantity).ToString ("0.##")} for quantity: {quantity}";
        }

        [HttpGet]
        [Route("/vat8/tax")]
        ///Calculate tax
        public string Tax(double price, int quantity)
        {
            return $"Tax: {_vatRepository.Tax(price, quantity).ToString ("0.##")} for quantity: {quantity}";
        }
    }
}