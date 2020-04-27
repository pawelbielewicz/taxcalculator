namespace PolishVATLib
{
    public class VatCalculationStrategyFactory
    {
        private static readonly IVATCalculation CalculationStrategy23 = new VAT23Calculation();
        private static readonly IVATCalculation CalculationStrategy8 = new VAT8Calculation();
        private static readonly IVATCalculation CalculationStrategy5 = new VAT5Calculation();
        private static readonly IVATCalculation CalculationStrategy0 = new VAT0Calculation();

        public IVATCalculation GetCalculationStrategy(VatType vatType)
        {
            switch (vatType)
            {
                case VatType.VAT5: return CalculationStrategy5;
                case VatType.VAT8: return CalculationStrategy8;
                case VatType.VAT23: return CalculationStrategy23;
                default: return CalculationStrategy0;
            }
        }
    }
}