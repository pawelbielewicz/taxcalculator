namespace PolishVATLib
{
    public class VATCalculator
    {
        private readonly VatCalculationStrategyFactory _calculationStrategyFactory;

        public VATCalculator()
        {
             _calculationStrategyFactory = new VatCalculationStrategyFactory();
        }

        public double CalculateGross(VatType vatType, double price, int quantity)
        {
            IVATCalculation calculationStrategy = 
                _calculationStrategyFactory.GetCalculationStrategy(vatType);
            
            return calculationStrategy.CalculateGrossAmount(price) * quantity;
        }

        public double CalculateNet(VatType vatType, double price, int quantity)
        {
            IVATCalculation calculationStrategy = 
                _calculationStrategyFactory.GetCalculationStrategy(vatType);
            
            return calculationStrategy.CalculateNetAmount(price) * quantity;
        }

        public double CalculateTax(VatType vatType, double price, int quantity)
        {
            IVATCalculation calculationStrategy = 
                _calculationStrategyFactory.GetCalculationStrategy(vatType);
            
            return calculationStrategy.CalculateTax(price) * quantity;
        }


    }
}