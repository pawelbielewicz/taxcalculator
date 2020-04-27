namespace PolishVATLib
{
    public class VATCalculator
    {
        private readonly VatCalculationStrategyFactory _calculationStrategyFactory;

        public VATCalculator()
        {
             _calculationStrategyFactory = new VatCalculationStrategyFactory();
        }

        public double CalculateGross(int vat, double price, int quantity)
        {
            VatType vatType = (VatType)vat;
            IVATCalculation calculationStrategy = 
                _calculationStrategyFactory.GetCalculationStrategy(vatType);
            
            return calculationStrategy.CalculateGrossAmount(price) * quantity;
        }

        public double CalculateNet(int vat, double price, int quantity)
        {
            VatType vatType = (VatType)vat;
            IVATCalculation calculationStrategy = 
                _calculationStrategyFactory.GetCalculationStrategy(vatType);
            
            return calculationStrategy.CalculateNetAmount(price) * quantity;
        }

        public double CalculateTax(int vat, double price, int quantity)
        {
            VatType vatType = (VatType)vat;
            IVATCalculation calculationStrategy = 
                _calculationStrategyFactory.GetCalculationStrategy(vatType);
            
            return calculationStrategy.CalculateTax(price) * quantity;
        }


    }
}