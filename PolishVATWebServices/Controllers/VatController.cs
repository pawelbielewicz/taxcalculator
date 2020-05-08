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
    public class VatController : ControllerBase
    {
        private readonly IEnumerable<string> _vatRates;

        private readonly ILogger<VatController> _logger;
        private readonly VATCalculator _vatCalculator;

        public VatController(ILogger<VatController> logger)
        {
            _logger = logger;
            _vatRates = new List<string>();
            _vatCalculator = new VATCalculator();
        }

        private Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            IEnumerable<IVATCalculation> objects = GetAssemblyByName("PolishVATLib")
            .GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.Name == "IVATCalculation"))
                .Select(x => (IVATCalculation)Activator.CreateInstance(x, null))
                .ToList();

            return objects.Select(x => x.GetType().GetProperties()[0].GetValue(x).ToString());
        }

        [HttpPost]
        public string Post([FromBody] IEnumerable<PolishVATLib.Product> products)
        {
            if (products is null || products.Count() == 0)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var calculatedAmount = 0.0;

            foreach(var good in products)
                calculatedAmount += _vatCalculator.CalculateGross(good.VatType, good.Price, 
                good.Quantity);

            return $"Calculated gross price for products: {calculatedAmount.ToString ("0.##")}";
        }

        [HttpPost]
        [Route("/net")]
        public string PostNet([FromBody] IEnumerable<PolishVATLib.Product> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var calculatedAmount = 0.0;

            foreach(var good in products)
                calculatedAmount += _vatCalculator.CalculateNet(good.VatType, good.Price, 
                good.Quantity);

            return $"Calculated net price for products: {calculatedAmount.ToString ("0.##")}";
        }

        [HttpPost]
        [Route("/tax")]
        public string PostTax([FromBody] IEnumerable<PolishVATLib.Product> products)
        {
            if (products is null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var calculatedAmount = 0.0;

            foreach(var good in products)
                calculatedAmount += _vatCalculator.CalculateTax(good.VatType, good.Price, 
                good.Quantity);

            return $"Calculated tax price for products: {calculatedAmount.ToString ("0.##")}";
        }
    }
}