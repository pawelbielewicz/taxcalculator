using System;
using Xunit;
using PolishVATLib;

namespace PolishVATTests
{
    public class VAT23Tests
    {
        private readonly IVATCalculation vatCalculation;
        
        public VAT23Tests()
        {
            vatCalculation = new VAT23Calculation();
        }

        [Fact]
        public void SingleGoodTestCalculateGross()
        {
            var myStandardGood = new { Name = "FancyCar", NetPrice = 30000 };
            var price = vatCalculation.CalculateGrossAmount(myStandardGood.NetPrice);
            Assert.Equal(36900, price);
        }

        [Fact]
        public void SingleGoodTestCalculateNet()
        {
            var myStandardGood = new { Name = "FancyCar", GrossPrice = 36900 };
            var price = vatCalculation.CalculateNetAmount(myStandardGood.GrossPrice);
            Assert.Equal(30000, price);
        }

        [Fact]
        public void CalculateTaxAmount()
        {
            var myStandardGood = new { Name = "My wonderful Mercedes", NetPrice = 120000 };
            var taxAmount = vatCalculation.CalculateTax(myStandardGood.NetPrice);
            Assert.Equal(27600, taxAmount);
        }
    }
}
