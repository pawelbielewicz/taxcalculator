using System;
using Xunit;
using PolishVATLib;
using System.Collections.Generic;
using System.Linq;

namespace PolishVATTests
{
    public class ProductsTests
    {
        [Fact]
        public void CalculateAmountForClient()
        {
            var customer = new Customer(new VAT23Calculation());
            customer.Add(12.0, 1);
            customer.Add(10.0, 1);
            customer.Add(5.0, 2);

            customer.Calculation = new VAT8Calculation();
            customer.Add(10, 2);

            Assert.Equal(60.96, customer.CalculatePrice());
        }
    }

    class Customer
    {
        private IList<double> _goods;

        public IVATCalculation Calculation { get; set; }

        public Customer(IVATCalculation strategy)
        {
            _goods = new List<double>();
            Calculation = strategy;
        }

        public void Add(double price, int quantity)
        {
            _goods.Add(Calculation.CalculateGrossAmount(price) * quantity);
        }

        public double CalculatePrice()
        {
            return _goods.AsEnumerable().Sum(g => g);
        }

    }
}