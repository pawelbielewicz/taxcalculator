using System;
using Xunit;
using PolishVATLib;

namespace PolishVATTests
{
    public class VAT5Tests
    {
        private readonly IVATCalculation vatCalculation;
        
        public VAT5Tests()
        {
            vatCalculation = new VAT5Calculation();
        }

        [Fact]
        public void SingleGoodTestCalculateGross()
        {
            var service = new { Name = "Programming in C#", NetPrice = 100 };
            var price = vatCalculation.CalculateGrossAmount(service.NetPrice);
            Assert.Equal(105, price);
        }

        [Fact]
        public void SingleGoodTestCalculateNet()
        {
            var service = new { Name = "Programming in C#", GrossPrice = 105 };
            var price = vatCalculation.CalculateNetAmount(service.GrossPrice);
            Assert.Equal(100, price);
        }

        [Fact]
        public void CalculateTaxAmount()
        {
            var service = new { Name = "Clean Code", NetPrice = 100 };
            var taxAmount = vatCalculation.CalculateTax(service.NetPrice);
            Assert.Equal(5, taxAmount);
        }
    }
}
