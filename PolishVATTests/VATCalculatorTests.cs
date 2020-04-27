using System;
using Xunit;
using PolishVATLib;

namespace PolishVATTests
{
    public class VATCalculatorTests
    {
        private readonly VATCalculator _vatCalculator;

        public VATCalculatorTests()
        {
            _vatCalculator = new VATCalculator();
        }

        [Fact]
        public void SimpleTestCalculateGross()
        {
            var goodies = new[] 
            {
                new { 
                    Name = "Some good with 23% VAT", 
                    VattType = 23, 
                    Quantity = 1, 
                    Price = 10 
                }
            };

            var calculatedAmount = 0.0;

            foreach(var good in goodies)
                calculatedAmount += _vatCalculator.CalculateGross(good.VattType, good.Price, 
                good.Quantity);

            Assert.Equal(12.3, calculatedAmount);
        }

        [Fact]
        public void SomeMoreTestCalculateGross()
        {
            var goodies = new[] 
            {
                new { 
                    Name = "Some good with 23% VAT", 
                    VattType = 23, 
                    Quantity = 1, 
                    Price = 10 
                },
                new { 
                    Name = "Another good with 23% VAT", 
                    VattType = 23, 
                    Quantity = 1, 
                    Price = 50
                },
                new { 
                    Name = "Just to have good with 23% VAT", 
                    VattType = 23, 
                    Quantity = 1, 
                    Price = 100 
                }
            };

            var calculatedAmount = 0.0;

            foreach(var good in goodies)
                calculatedAmount += _vatCalculator.CalculateGross(good.VattType, good.Price, 
                good.Quantity);

            Assert.Equal(196.8, calculatedAmount);
        }

        [Fact]
        public void SomeMixedTestCalculateGross()
        {
            var goodies = new[] 
            {
                new { 
                    Name = "Some good with 23% VAT", 
                    VattType = 23, 
                    Quantity = 1, 
                    Price = 10 
                },
                new { 
                    Name = "Some good with 8% VAT", 
                    VattType = 8,
                    Quantity = 1, 
                    Price = 10
                },
                new { 
                    Name = "And one with with 5% VAT", 
                    VattType = 5, 
                    Quantity = 1, 
                    Price = 10 
                }
            };

            var calculatedAmount = 0.0;

            foreach(var good in goodies)
                calculatedAmount += _vatCalculator.CalculateGross(good.VattType, good.Price, 
                good.Quantity);

            Assert.Equal(33.6, calculatedAmount);
        }
    }
}