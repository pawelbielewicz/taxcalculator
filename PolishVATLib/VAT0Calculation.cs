namespace PolishVATLib
{
    public class VAT0Calculation : IVATCalculation
    {
        public string Name => "0%";

        public VAT0Calculation()
        {

        }

        public double CalculateGrossAmount(double netPrice)
        {
            return netPrice;
        }

        public double CalculateNetAmount(double grossPrice)
        {
            return grossPrice;
        }

        public double CalculateTax(double netPrice)
        {
            return 0;
        }
    }
}
