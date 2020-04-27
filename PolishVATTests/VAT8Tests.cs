using System;
using Xunit;
using PolishVATLib;

namespace PolishVATTests
{
    public class VAT8Tests
    {
        private readonly IVATCalculation vatCalculation;
        
        public VAT8Tests()
        {
            vatCalculation = new VAT8Calculation();
        }

        [Fact]
        public void SingleGoodTestCalculateGross()
        {
            var service = new { Name = "Service for 8% VAT", NetPrice = 5000 };
            var price = vatCalculation.CalculateGrossAmount(service.NetPrice);
            Assert.Equal(5400, price);
        }

        [Fact]
        public void SingleGoodTestCalculateNet()
        {
            var service = new { Name = "Service for 8% VAT", GrossPrice = 5400 };
            var price = vatCalculation.CalculateNetAmount(service.GrossPrice);
            Assert.Equal(5000, price);
        }

        [Fact]
        public void CalculateTaxAmount()
        {
            var service = new { Name = "Just the service", NetPrice = 5000 };
            var taxAmount = vatCalculation.CalculateTax(service.NetPrice);
            Assert.Equal(400, taxAmount);
        }
    }
}
