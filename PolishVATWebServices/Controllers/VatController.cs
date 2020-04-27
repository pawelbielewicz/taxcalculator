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

        public VatController(ILogger<VatController> logger)
        {
            _logger = logger;
            _vatRates = new List<string>();
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

            return objects.Select(x => x.GetType().GetProperties()[0].GetValue(x).ToString()).ToList();
        }
    }
}