namespace PolishVATLib
{
    public class VAT5Calculation : IVATCalculation
    {
        public string Name => "5%";

        public VAT5Calculation()
        {

        }
        
        public double CalculateGrossAmount(double netPrice)
        {
            return netPrice * 1.05;
        }

        public double CalculateNetAmount(double grossPrice)
        {
            return grossPrice / 1.05;
        }

        public double CalculateTax(double netPrice)
        {
            return netPrice * 0.05;
        }
    }
}